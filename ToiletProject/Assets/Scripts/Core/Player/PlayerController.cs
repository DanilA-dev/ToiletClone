using Systems;
using Core.Interfaces;
using Core.Level;
using Core.Player.PlayerStates;
using Core.Player.PlayerStates.StateSerializeData;
using CustomFSM.Preicate;
using CustomFSM.State;
using Data;
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
        
        private PlayerMoveState _moveState;
        private PlayerCombatState _combatState;
        private PlayerAttackState _attackState;
        private PlayerBlockState _blockState;

        private GameState _gameState;
        private ILevelStageHandler _levelStageHandler;
        private HealthSystem _healthSystem;
        private PlayerStatsData _playerStatsData;
        private TargetController _targetController;
        private PlayerActionReceiver _actionReceiver;
        
        private bool _isAttacking;
        private bool _isBlocking;


        #region Properties
        public Transform Transform => transform;
        public HealthSystem Health => _healthSystem;
        public override IState StartState => _moveState;

        #endregion

        [Inject]
        private void Construct(GameState gameState, PlayerStatsData playerStatsData,
            ILevelStageHandler levelStageHandler, TargetController targetController,
            PlayerActionReceiver actionReceiver)
        {
            _gameState = gameState;
            _actionReceiver = actionReceiver;
            _levelStageHandler = levelStageHandler;
            _targetController = targetController;
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
            _targetController.OnTargetUpdate += SetTarget;
            _healthSystem.OnDie += Die;
            
            SetTarget(_targetController.GetTarget());

        }
     
        protected override void Update()
        {
            if(_gameState.IsGameOver)
                return;
            
            base.Update();
        }

        protected override void InitStatesAndTransitions()
        {
            _moveState = new PlayerMoveState(_view,_moveStateData, this, _levelStageHandler);
            _combatState = new PlayerCombatState(_view,  this, _combatStateData);
            _attackState = new PlayerAttackState(_view,  this, _playerStatsData);
            _blockState = new PlayerBlockState(_view, this);
            
            AddTransition(_moveState, _combatState, new FuncPredicate(IsNearStagePoint));
            AddTransition(_combatState, _attackState, new FuncPredicate(() =>_actionReceiver.IsAttacking));
            AddTransition(_combatState, _blockState, new FuncPredicate(() => _actionReceiver.IsBlocking));
            AddTransition(_attackState, _combatState, new FuncPredicate(() => !_actionReceiver.IsAttacking));
            AddTransition(_blockState, _combatState, new FuncPredicate(() => !_actionReceiver.IsBlocking));
            _stateMachine.SetState(StartState);
        }
        
      
        private void SetTarget(ITarget newTarget)
        {
            _combatState.SetEnemy(newTarget);
            _attackState.SetEnemy(newTarget);
        }
        
        private bool IsNearStagePoint()
            => Vector3.Distance(transform.position, _levelStageHandler.GetNextStage().GetPoint.position) <= _moveStateData.StopDistance;


        private void Die()
        {
            
        }
        
        
    }
}