using Systems;
using Core.Interfaces;
using Core.Level;
using Core.Player.PlayerStates;
using Core.Player.PlayerStates.StateSerializeData;
using CustomFSM.Preicate;
using CustomFSM.State;
using Data.PlayerStats;
using Entity;
using UnityEngine;
using Zenject;

namespace Core.Player
{
    [RequireComponent(typeof(HealthSystem))]
    public class PlayerController : BaseFSMActor, ITarget
    {
        [SerializeField] private PlayerView _view;
        [SerializeField] private PlayerMoveSerializeData _moveStateData;
        [SerializeField] private PlayerCombatSerializeData _combatStateData;
        [SerializeField] private TargetDetectionSystem _targetDetectionSystem;
        
        private PlayerMoveState _moveState;
        private PlayerCombatState _combatState;
        private PlayerAttackState _attackState;
        private PlayerBlockState _blockState;
        private PlayerDeathState _deathState;
        
        
        private ILevelStageHandler _levelStageHandler;
        private ITarget _target;
        private GameState _gameState;
        private HealthSystem _healthSystem;
        private PlayerStatsData _playerStatsData;
        private PlayerActionReceiver _actionReceiver;
        
        private bool _isAttacking;
        private bool _isBlocking;


        #region Properties

        private bool HasTarget => _target != null;
        public TargetEntity TargetEntity => TargetEntity.Player;
        public Transform Transform => transform;
        public HealthSystem Health => _healthSystem;
        public override IState StartState => _moveState;

        #endregion

        [Inject]
        private void Construct(GameState gameState, PlayerStatsData playerStatsData,
            ILevelStageHandler levelStageHandler,
            PlayerActionReceiver actionReceiver)
        {
            _gameState = gameState;
            _actionReceiver = actionReceiver;
            _levelStageHandler = levelStageHandler;
            _playerStatsData = playerStatsData;
        }

        private void Awake()
        {
           Init();
        }

        private void Init()
        {
            _healthSystem = GetComponent<HealthSystem>();
            _healthSystem.SetMaxHealth(_playerStatsData.MaxHealth);
            InitStateMachine();
            InitStatesAndTransitions();
            
            _healthSystem.OnHealhChange += (cur, max) => _view.Damaged();
            _healthSystem.OnDie += OnPlayerDeath;
        }
     
        protected override void Update()
        {
            if(_gameState.IsGameOver)
                return;
            
            base.Update();

            FindTarget();
        }

        private void FindTarget()
        {
            if (_targetDetectionSystem.TryFindTarget(out var target))
                SetTarget(target);
        }

        protected override void InitStatesAndTransitions()
        {
            _moveState = new PlayerMoveState(_view,_moveStateData, this, _levelStageHandler);
            _combatState = new PlayerCombatState(_view,  this, _combatStateData);
            _attackState = new PlayerAttackState(_view,  this, _playerStatsData);
            _blockState = new PlayerBlockState(_view, this);
            _deathState = new PlayerDeathState(_view, this);
            
            AddTransition(_moveState, _combatState, new FuncPredicate(() => HasTarget));
            AddTransition(_combatState, _moveState, new FuncPredicate(() => !HasTarget));
            AddTransition(_combatState, _attackState, new FuncPredicate(() =>_actionReceiver.IsAttacking));
            AddTransition(_combatState, _blockState, new FuncPredicate(() => _actionReceiver.IsBlocking));
            AddTransition(_attackState, _combatState, new FuncPredicate(() => !_actionReceiver.IsAttacking));
            AddTransition(_blockState, _combatState, new FuncPredicate(() => !_actionReceiver.IsBlocking));
            AddTransition(_combatState,_deathState, new FuncPredicate(() => _healthSystem.IsDead));
            StateMachine.SetState(StartState);
        }
        
      
        private void SetTarget(ITarget newTarget)
        {
            if(HasTarget)
                return;
            
            _target = newTarget;
            _target.Health.OnDie += ResetTarget;
            _combatState.SetEnemy(_target);
            _attackState.SetEnemy(_target);
        }

        private void ResetTarget()
        {
            _target.Health.OnDie -= ResetTarget;
            _target = null;
        }

        private bool IsNearStagePoint()
            => Vector3.Distance(transform.position, _levelStageHandler.GetNextStage().GetPoint.position) <= _moveStateData.StopDistance;


        private void OnPlayerDeath()
        {
            _gameState.SetGameOver(GameOverType.Lose);
        }


        private void OnDrawGizmosSelected()
        {
            _targetDetectionSystem.DrawGizmos();
        }
    }
}