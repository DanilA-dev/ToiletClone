using Core.Player;
using CustomFSM.State;

namespace Core.Enemy.EnemyStates
{
    public abstract class BaseEnemyState : IState
    {
        protected PlayerController _player;
        protected EnemyView _view;
        
        public BaseEnemyState(PlayerController playerController)
        {
            _player = playerController;
        }
        
        public abstract void OnEnter();

        public virtual void OnUpdate(){}

        public virtual void OnFixedUpdate(){}

        public abstract void OnExit();
    }
}