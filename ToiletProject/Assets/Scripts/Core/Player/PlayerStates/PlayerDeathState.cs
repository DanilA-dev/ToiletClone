namespace Core.Player.PlayerStates
{
    public class PlayerDeathState : BasePlayerState
    {
        public PlayerDeathState(PlayerView view, PlayerController playerController) : base(view, playerController)
        {
        }

        public override void OnEnter()
        {
            _view.Die();
        }

        public override void OnExit()
        {
        }
    }
}