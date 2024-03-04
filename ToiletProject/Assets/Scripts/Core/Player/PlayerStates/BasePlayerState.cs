using Core.Level;
using CustomFSM.State;

namespace Core.Player.PlayerStates
{
    public abstract class BasePlayerState : IState
    {
        protected PlayerController _playerController;
        protected readonly PlayerView _view;
        protected readonly LevelStageHandler _stageHandler;

        public BasePlayerState(PlayerView view, LevelStageHandler stageHandler, PlayerController playerController)
        {
            _view = view;
            _playerController = playerController;
            _stageHandler = stageHandler;
        }
        
        public abstract void OnEnter();

        public virtual void OnUpdate(){}

        public virtual void OnFixedUpdate(){}

        public abstract void OnExit();

    }
}