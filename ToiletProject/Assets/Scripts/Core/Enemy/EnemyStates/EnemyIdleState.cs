using Core.Interfaces;

namespace Core.Enemy.EnemyStates
{
    public class EnemyIdleState : BaseEnemyState
    {
        
        public EnemyIdleState(EnemyController enemyController, EnemyView view) : base(enemyController, view)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }
        
        public override string ToString()
        {
            return "Idle";
        }
    }
}