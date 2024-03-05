using System;
using Systems;
using Core.Enemy;
using Core.Level;
using Core.Player.PlayerStates;
using Core.Player.PlayerStates.StateSerializeData;
using CustomFSM.Preicate;
using CustomFSM.State;
using Data;
using Entity;
using FSM.FSM;
using UniRx;
using UnityEngine;

namespace Core.Player
{
    [RequireComponent(typeof(HealthSystem))]
    public class PlayerController : BaseFSMActor
    {
        [SerializeField] private PlayerView _view;
        [SerializeField] private PlayerMoveSerializeData _moveStateData;
        [SerializeField] private PlayerCombatSerializeData _combatStateData;
        
        private PlayerMoveState _moveState;
        private PlayerCombatState _combatState;
        private PlayerAttackState _attackState;
        private PlayerBlockState _blockState;

        private LevelStageHandler _levelStageHandler;
        private HealthSystem _healthSystem;
        private PlayerData _playerData;
        private GameState _gameState;
        private TargetController _targetController;
        
        private bool _isAttacking;
        private bool _isBlocking;

        private Action OnStageChangeAction;
        
        public HealthSystem HealthSystem => _healthSystem;
        public override IState StartState => _moveState;

        private void Awake()
        {
            _healthSystem = GetComponent<HealthSystem>();
        }

        public void Init(PlayerData playerData, LevelStageHandler levelStageHandler, GameState gameState, TargetController targetController)
        {
            _gameState = gameState;
            _levelStageHandler = levelStageHandler;
            _targetController = targetController;
            _playerData = playerData;
            _healthSystem.SetMaxHealth(playerData.MaxHealth);
            InitStateMachine();
            InitStatesAndTransitions();

            MessageBroker.Default.Receive<PlayerCoreAction>()
                .Where(a => a.PlayerCoreActionType == PlayerCoreActionType.Attack)
                .Subscribe(s => AttackSignalInvoke()).AddTo(gameObject);
            
            MessageBroker.Default.Receive<PlayerCoreAction>()
                .Where(a => a.PlayerCoreActionType == PlayerCoreActionType.Block)
                .Subscribe(s => BlockSignalInvoke()).AddTo(gameObject);
            
            MessageBroker.Default.Receive<PlayerCoreAction>()
                .Where(a => a.PlayerCoreActionType == PlayerCoreActionType.None)
                .Subscribe(s => NoActionSignalInvoke()).AddTo(gameObject);
            
            _healthSystem.OnHealhChange += (cur, max) => _view.Damaged();
            _gameState.CurrentStage.Subscribe(_ => OnStageChangeAction?.Invoke()).AddTo(gameObject);
            _targetController.OnTargetUpdate += SetTarget;
        }

        private void AttackSignalInvoke()
        {
            _isAttacking = true;
            _isBlocking = false;
        }

        private void BlockSignalInvoke()
        {
            _isBlocking = true;
            _isAttacking = false;
        }

        private void NoActionSignalInvoke()
        {
            _isBlocking = false;
            _isAttacking = false;
        }

        protected override void InitStatesAndTransitions()
        {
            _moveState = new PlayerMoveState(_view, _levelStageHandler, _moveStateData, this);
            _combatState = new PlayerCombatState(_view, _levelStageHandler, this, _combatStateData);
            _attackState = new PlayerAttackState(_view, _levelStageHandler, this);
            _blockState = new PlayerBlockState(_view, _levelStageHandler, this);
            
            AddTransition(_moveState, _combatState, new FuncPredicate(IsNearStagePoint));
            AddTransition(_combatState, _attackState, new FuncPredicate(() => _isAttacking));
            AddTransition(_combatState, _blockState, new FuncPredicate(() => _isBlocking));
            AddTransition(_attackState, _combatState, new FuncPredicate(() => !_isAttacking));
            AddTransition(_blockState, _combatState, new FuncPredicate(() => !_isBlocking));
            AddTransition(_combatState, _moveState, new ActionPredicate(OnStageChangeAction));
            _stateMachine.SetState(StartState);
        }
        
      
        private void SetTarget(EnemyController newTarget)
        {
            _combatState.SetEnemy(newTarget);
            _attackState.SetEnemy(newTarget);
        }
        
        private bool IsNearStagePoint()
            => Vector3.Distance(transform.position, _levelStageHandler.GetNextStage().GetPoint.position) <= _moveStateData.StopDistance;
       
        
    }
}