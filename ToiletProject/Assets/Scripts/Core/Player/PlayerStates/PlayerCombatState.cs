using Core.Interfaces;

namespace Core.Player.PlayerStates
{
    public class PlayerCombatState : BasePlayerState
    {
        private ITarget _currentEnemy;
        private readonly PlayerCombatSerializeData _combatSerializeData;
        
        public PlayerCombatState(PlayerView view,PlayerController playerController, PlayerCombatSerializeData serializeData)
            : base(view, playerController)
        {
            _combatSerializeData = serializeData;
        }

        public override void OnEnter()
        {
            _view.Combat();
        }

        public void SetEnemy(ITarget enemy)
        {
            _currentEnemy = enemy;
        }
        
        public override void OnUpdate()
        {
            RotateTowardsEnemy();
        }

        private void RotateTowardsEnemy()
        {
            if(_currentEnemy == null)
                return;

            _playerController.transform.LookAt(_currentEnemy.Transform);
        }

        public override void OnExit()
        {
        }

        public override string ToString()
        {
            return "Combat";
        }
    }
}