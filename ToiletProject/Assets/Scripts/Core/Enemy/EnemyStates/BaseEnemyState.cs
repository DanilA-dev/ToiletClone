using Core.Player;
using CustomFSM.State;

namespace Core.Enemy.EnemyStates
{
    public abstract class BaseEnemyState : IState
    {
        protected PlayerController _player;
        protected EnemyView _view;
        
        public BaseEnemyState(PlayerController playerController, EnemyView view)
        {
            _player = playerController;
            _view = view;
        }
        
        public abstract void OnEnter();

        public virtual void OnUpdate(){}

        public virtual void OnFixedUpdate(){}

        public abstract void OnExit();
    }
}