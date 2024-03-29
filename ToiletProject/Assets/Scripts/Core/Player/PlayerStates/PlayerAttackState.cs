using Systems;
using Core.Interfaces;
using Data.PlayerStats;

namespace Core.Player.PlayerStates
{
    public class PlayerAttackState : BasePlayerState
    {
        private ITarget _currentEnemy;
        private PlayerStatsData _statsData;
        
        public PlayerAttackState(PlayerView view, PlayerController playerController, PlayerStatsData statsData)
             : base(view, playerController)
        {
            _statsData = statsData;
        }

        public override void OnEnter()
        {
            AttackEnemy();
        }

        public void SetEnemy(ITarget enemy)
        {
            _currentEnemy = enemy;
        }
        private void AttackEnemy()
        {
            _view.Attack();
            var damageStat = _statsData.GetStatValueByType(PlayerStatType.Damage);
            _currentEnemy.Health.Damage(damageStat.CurrentValue);
        }
        
        public override void OnExit()
        {
        }
        
        public override string ToString()
        {
            return "Attack";
        }
    }
}