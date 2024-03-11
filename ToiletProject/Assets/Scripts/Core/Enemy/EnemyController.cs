using System;
using System.Collections.Generic;
using Systems;
using Core.Enemy.EnemyStates;
using Core.Player;
using CustomFSM.Preicate;
using CustomFSM.State;
using Entity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Enemy
{
    [RequireComponent(typeof(HealthSystem))]
    public class EnemyController : BaseFSMActor
    {
        [SerializeField] private float _attackDist;
        [SerializeField] private EnemyView _view;
        [SerializeField] private EnemyAttackSerializeData _attackData;
        [SerializeField] private EnemyChaseSerializeData _chaseData;

        private PlayerController _player;
        private HealthSystem _healthSystem;
        
        private CountdownTimer _attackDelayTimer;
        private CountdownTimer _attackTimer;
        private List<BaseTimer> _timers;

        private EnemyChaseState _chaseState;
        private EnemyAttackState _attackState;
        private EnemyDeadState _deadState;
        private EnemyCombatState _combatState;
        private bool _isAttacking;
        
        public HealthSystem Health => _healthSystem;
        public override IState StartState => _chaseState;

        private void Awake()
        {
            _healthSystem = GetComponent<HealthSystem>();
            
            var delayTime = Random.Range(_attackData.MinBeforeAttackTime, _attackData.MaxBeforeAttackTime);
            _attackDelayTimer = new CountdownTimer(delayTime);
            _attackTimer = new CountdownTimer(_attackData.AttackTime);
            
            _timers = new List<BaseTimer>
            {
                _attackTimer,
                _attackDelayTimer
            };
        }

        public void Init(PlayerController playerController)
        {
            _player = playerController;
            InitStateMachine();
            InitStatesAndTransitions();
        }

        protected override void Update()
        {
            base.Update();
            
            foreach (var timer in _timers)
                timer.Tick(Time.deltaTime);
        }

        protected override void InitStatesAndTransitions()
        {
            _chaseState = new EnemyChaseState(_player, _chaseData, _view);
            _attackState = new EnemyAttackState(_player, _attackData, _view);
            _deadState = new EnemyDeadState(_player, _view);
            _combatState = new EnemyCombatState(_player, _view, this);
            
            AddTransition(_chaseState, _combatState, new FuncPredicate((IsNearPlayer)));
            AddTransition(_combatState, _attackState, new FuncPredicate(() => _isAttacking));
            AddTransition(_attackState, _combatState, new FuncPredicate(() => !_isAttacking));
            AddAnyTransition(_deadState, new FuncPredicate(() => _healthSystem.IsDead));
            
            _stateMachine.SetState(StartState);
        }

        public void EnterCombat()
        {
            _attackDelayTimer.Start();
            _attackDelayTimer.OnTimerEnd += Attack;
        }
        
        private void Attack()
        {
            if(_isAttacking)
                return;
                        
            _isAttacking = true;
            _attackTimer.Start();
            _view.Attack();
            _player.HealthSystem.Damage(_attackData.Damage);
            _attackTimer.OnTimerEnd += Cooldown;
        }
        
        private void Cooldown()
        {
            _isAttacking = false;
            _attackDelayTimer.Reset();
        }

        
        private bool IsNearPlayer()
        {
            return Vector3.Distance(transform.position, _player.transform.position) <= _attackDist;
        }
    }
}