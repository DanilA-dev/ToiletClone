using Core.Player;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyDeadState : BaseEnemyState
    {
        public EnemyDeadState(PlayerController playerController) : base(playerController)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Enter Dead state");
        }

        public override void OnExit()
        {
            Debug.Log("Exit Dead state");
        }
    }
}