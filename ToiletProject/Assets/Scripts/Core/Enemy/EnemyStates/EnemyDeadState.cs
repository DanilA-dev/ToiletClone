using Core.Interfaces;

namespace Core.Enemy.EnemyStates
{
    public class EnemyDeadState : BaseEnemyState
    {
        public EnemyDeadState(EnemyController enemyController, EnemyView view)
            : base(enemyController, view)
        {
        }

        public override void OnEnter()
        {
            _view.Die();
        }

        public override void OnExit()
        {
        }
        
        public override string ToString()
        {
            return "Dead";
        }
    }
}