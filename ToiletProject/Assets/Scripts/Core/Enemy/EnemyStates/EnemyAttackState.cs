
namespace Core.Enemy.EnemyStates
{
    public class EnemyAttackState : BaseEnemyState
    {

        public EnemyAttackState(EnemyController enemyController,
            EnemyView view) : base(enemyController, view)
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
            return "Attack";
        }
    }
}