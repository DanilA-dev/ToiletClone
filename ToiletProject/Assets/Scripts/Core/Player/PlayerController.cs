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
        private PlayerActionReceiver _actionReceiver;
        
        private bool _isAttacking;
        private bool _isBlocking;

        
        public HealthSystem HealthSystem => _healthSystem;
        public override IState StartState => _moveState;

        private void Awake()
        {
            _healthSystem = GetComponent<HealthSystem>();
        }

        public void Init(PlayerData playerData, LevelStageHandler levelStageHandler,
            GameState gameState, TargetController targetController, PlayerActionReceiver actionReceiver)
        {
            _gameState = gameState;
            _actionReceiver = actionReceiver;
            _levelStageHandler = levelStageHandler;
            _targetController = targetController;
            _playerData = playerData;
            _healthSystem.SetMaxHealth(playerData.MaxHealth);
            InitStateMachine();
            InitStatesAndTransitions();
            
            _healthSystem.OnHealhChange += (cur, max) => _view.Damaged();
            _targetController.OnTargetUpdate += SetTarget;
            _healthSystem.OnDie += () =>
            {
                _gameState.IsGameOver.Value = true;
                _gameState.EndGameState.Value = GameOverType.Lose;
            };
        }

        private void Start()
        {
            SetTarget(_targetController.GetTarget());
        }

        protected override void Update()
        {
            if(_gameState.IsGameOver.Value)
                return;
            
            base.Update();
        }

        protected override void InitStatesAndTransitions()
        {
            _moveState = new PlayerMoveState(_view, _levelStageHandler, _moveStateData, this);
            _combatState = new PlayerCombatState(_view, _levelStageHandler, this, _combatStateData);
            _attackState = new PlayerAttackState(_view, _levelStageHandler, this, _playerData);
            _blockState = new PlayerBlockState(_view, _levelStageHandler, this);
            
            AddTransition(_moveState, _combatState, new FuncPredicate(IsNearStagePoint));
            AddTransition(_combatState, _attackState, new FuncPredicate(() =>_actionReceiver.IsAttacking));
            AddTransition(_combatState, _blockState, new FuncPredicate(() => _actionReceiver.IsBlocking));
            AddTransition(_attackState, _combatState, new FuncPredicate(() => !_actionReceiver.IsAttacking));
            AddTransition(_blockState, _combatState, new FuncPredicate(() => !_actionReceiver.IsBlocking));
            AddTransition(_combatState, _moveState,new FuncPredicate((() => _gameState.IsStageClear.Value)));
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