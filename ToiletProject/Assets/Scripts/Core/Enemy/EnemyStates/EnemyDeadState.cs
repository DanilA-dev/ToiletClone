using Core.Interfaces;

namespace Core.Enemy.EnemyStates
{
    public class EnemyDeadState : BaseEnemyState
    {
        public EnemyDeadState(EnemyController enemyController,ITarget target, EnemyView view)
            : base(enemyController,target, view)
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