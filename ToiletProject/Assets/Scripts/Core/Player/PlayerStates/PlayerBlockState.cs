using Systems;

namespace Core.Player.PlayerStates
{
    public class PlayerBlockState : BasePlayerState
    {
        private readonly HealthSystem _playerHealth;
        
        public PlayerBlockState(PlayerView view, PlayerController playerController) : base(view, playerController)
        {
            _playerHealth = _playerController.GetComponent<HealthSystem>();
        }

        public override void OnEnter()
        {
            _playerHealth.SetDamagable(false);
            _view.Block();
        }

        public override void OnExit()
        {
            _playerHealth.SetDamagable(true);
        }
    }
}