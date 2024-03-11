using Systems;
using Core.Level;
using UniRx;
using UnityEngine;

namespace Core.Player.PlayerStates
{
    public class PlayerBlockState : BasePlayerState
    {
        private HealthSystem _playerHealth;
        
        public PlayerBlockState(PlayerView view, LevelStageHandler stageHandler,
            PlayerController playerController) : base(view, stageHandler, playerController)
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