using System.Collections.Generic;
using Systems;
using Core.Enemy.EnemyStates;
using Core.Interfaces;
using CustomFSM.Preicate;
using CustomFSM.State;
using Entity;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Core.Enemy
{
    [RequireComponent(typeof(HealthSystem))]
    public class EnemyController : BaseFSMActor, ITarget
    {
        [SerializeField] private float _attackDist;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private NavMeshAgent _navAgent;
        [SerializeField] private EnemyView _view;
        [SerializeField] private EnemyAttackSerializeData _attackData;
        [SerializeField] private EnemyChaseSerializeData _chaseData;
        [SerializeField] private TargetDetectionSystem _targetDetectionSystem;

        private ITarget _target;
        private HealthSystem _healthSystem;
        
        private CountdownTimer _attackDelayTimer;
        private CountdownTimer _attackTimer;
        private List<BaseTimer> _timers;

        private EnemyIdleState _idleState;
        private EnemyChaseState _chaseState;
        private EnemyAttackState _attackState;
        private EnemyDeadState _deadState;
        private EnemyCombatState _combatState;
        private bool _isAttacking;

        #region Properties
        public TargetEntity TargetEntity => TargetEntity.Enemy;
        public Transform Transform => transform;
        public HealthSystem Health => _healthSystem;
        public override IState StartState => _idleState;
        public NavMeshAgent Agent => _navAgent;
        public float RotationSpeed => _rotationSpeed;
        private bool IsPlayerDead => _target != null && _target.Health.IsDead;

        #endregion
       

        private void Awake()
        {
            InitStateMachine();
            InitStatesAndTransitions();
            
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


        protected override void Update()
        {
            base.Update();

            if (_targetDetectionSystem.TryFindTarget(out var target))
                SetTarget(target);
            
            foreach (var timer in _timers)
                timer.Tick(Time.deltaTime);
        }

        protected override void InitStatesAndTransitions()
        {
            _idleState = new EnemyIdleState(this, _view);
            _chaseState = new EnemyChaseState(this, _chaseData, _view);
            _attackState = new EnemyAttackState(this, _view);
            _deadState = new EnemyDeadState(this, _view);
            _combatState = new EnemyCombatState(this, _view);
            
            AddTransition(_idleState, _chaseState, new FuncPredicate(() => !IsPlayerDead && _target != null));
            AddTransition(_chaseState, _combatState, new FuncPredicate(() => !IsPlayerDead && IsNearPlayer()));
            AddTransition(_combatState, _attackState, new FuncPredicate(() => _isAttacking));
            AddTransition(_attackState, _combatState, new FuncPredicate(() => !_isAttacking));
            AddTransition(_combatState, _idleState, new FuncPredicate(() => IsPlayerDead));
            AddAnyTransition(_deadState, new FuncPredicate(() => _healthSystem.IsDead));
            
            StateMachine.SetState(StartState);
        }

        private void SetTarget(ITarget target)
        {
            _target = target;
            _chaseState.SetTarget(target);
            _combatState.SetTarget(target);
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
            _target.Health.Damage(_attackData.Damage);
            _attackTimer.OnTimerEnd += Cooldown;
        }
        
        private void Cooldown()
        {
            _isAttacking = false;
            _attackDelayTimer.Reset();
        }

        
        private bool IsNearPlayer()
        {
            if (_target == null)
                return false;
            
            return Vector3.Distance(transform.position, _target.Transform.position) <= _attackDist;
        }

        private void OnDrawGizmosSelected()
        {
            _targetDetectionSystem?.DrawGizmos();
        }
    }
}