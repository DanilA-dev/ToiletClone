using Core.Player;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyDeadState : BaseEnemyState
    {
        public EnemyDeadState(PlayerController playerController, EnemyView view) : base(playerController, view)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Enter Dead state");
            _view.Die();
        }

        public override void OnExit()
        {
            Debug.Log("Exit Dead state");
        }
    }
}