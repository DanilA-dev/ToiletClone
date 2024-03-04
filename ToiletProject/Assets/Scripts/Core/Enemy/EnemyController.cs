using Systems;
using Core.Enemy.EnemyStates;
using Core.Player;
using CustomFSM.Preicate;
using CustomFSM.State;
using Entity;
using UnityEngine;

namespace Core.Enemy
{
    public class EnemyController : BaseFSMActor
    {
        [SerializeField] private float _attackDist;
        [SerializeField] private EnemyAttackSerializeData _attackData;
        [SerializeField] private EnemyChaseSerializeData _chaseData;

        private PlayerController _player;
        private HealthSystem _healthSystem;
        
        private EnemyChaseState _chaseState;
        private EnemyAttackState _attackState;
        private EnemyDeadState _deadState;
        
        
        public HealthSystem Health => _healthSystem;
        public override IState StartState => _chaseState;

        public void Init(PlayerController playerController)
        {
            _player = playerController;
            _healthSystem = GetComponent<HealthSystem>();
        }
        
        protected override void InitStatesAndTransitions()
        {
            _chaseState = new EnemyChaseState(_player, _chaseData);
            _attackState = new EnemyAttackState(_player, _attackData);
            _deadState = new EnemyDeadState(_player);
            
            AddTransition(_chaseState, _attackState, new FuncPredicate((IsNearPlayer)));
            AddTransition(_attackState, _deadState, new FuncPredicate((() => _healthSystem.IsDead)));
            
            _stateMachine.SetState(StartState);
        }

        private bool IsNearPlayer()
        {
            return Vector3.Distance(transform.position, _player.transform.position) <= _attackDist;
        }
    }
}