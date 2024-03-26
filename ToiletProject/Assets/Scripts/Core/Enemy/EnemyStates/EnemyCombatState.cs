using Core.Interfaces;

namespace Core.Enemy.EnemyStates
{
    public class EnemyCombatState : BaseEnemyState
    {
        private readonly EnemyController _enemy;
        
        public EnemyCombatState(EnemyController enemyController, EnemyView view) 
            : base(enemyController, view)
        {
            _enemy = enemyController;
        }

        public override void OnEnter()
        {
            _enemy.EnterCombat();
            _view.Idle();
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