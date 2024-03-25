using Core.Interfaces;

namespace Core.Enemy.EnemyStates
{
    public class EnemyCombatState : BaseEnemyState
    {
        private readonly EnemyController _enemy;
        
        public EnemyCombatState(EnemyController enemyController,ITarget target, EnemyView view) 
            : base(enemyController,target, view)
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
    }
}