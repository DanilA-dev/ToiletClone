using Systems;
using Core.Level;
using Core.Player.PlayerStates;
using Core.Player.PlayerStates.StateSerializeData;
using CustomFSM.Preicate;
using CustomFSM.State;
using Data;
using Entity;
using UnityEngine;

namespace Core.Player
{
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
        
        private bool _isAttacking;
        private bool _isBlocking;
        
        public HealthSystem HealthSystem => _healthSystem;
        public override IState StartState => _moveState;

        public void Init(PlayerData playerData, LevelStageHandler levelStageHandler)
        {
            _levelStageHandler = levelStageHandler;
            _playerData = playerData;
            _healthSystem = GetComponent<HealthSystem>();
            _healthSystem.SetMaxHealth(playerData.MaxHealth);
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
            
            _stateMachine.SetState(StartState);
        }
        
        private bool IsNearStagePoint()
            => Vector3.Distance(transform.position, _levelStageHandler.GetNextStage().GetPoint.position) <= _moveStateData.StopDistance;
       
        
    }
}