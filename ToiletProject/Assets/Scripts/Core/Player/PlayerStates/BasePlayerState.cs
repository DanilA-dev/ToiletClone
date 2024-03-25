using CustomFSM.State;

namespace Core.Player.PlayerStates
{
    public abstract class BasePlayerState : IState
    {
        protected readonly PlayerController _playerController;
        protected readonly PlayerView _view;

        public BasePlayerState(PlayerView view, PlayerController playerController)
        {
            _view = view;
            _playerController = playerController;
        }
        
        public abstract void OnEnter();

        public virtual void OnUpdate(){}

        public virtual void OnFixedUpdate(){}

        public abstract void OnExit();

    }
}