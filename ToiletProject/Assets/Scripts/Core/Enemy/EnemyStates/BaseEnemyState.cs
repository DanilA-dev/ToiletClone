using Core.Interfaces;
using CustomFSM.State;

namespace Core.Enemy.EnemyStates
{
    public abstract class BaseEnemyState : IState
    {
        protected readonly EnemyController _enemyController;
        protected readonly EnemyView _view;
        
        public BaseEnemyState(EnemyController enemyController,EnemyView view)
        {
            _enemyController = enemyController;
            _view = view;
        }
        
        public abstract void OnEnter();

        public virtual void OnUpdate(){}

        public virtual void OnFixedUpdate(){}

        public abstract void OnExit();
    }
}