using Core.Player;
using UnityEngine;

namespace Core.Enemy.EnemyStates
{
    public class EnemyCombatState : BaseEnemyState
    {
        private EnemyController _enemy;
        
        public EnemyCombatState(PlayerController playerController, EnemyView view, EnemyController enemyController) : base(playerController, view)
        {
            _enemy = enemyController;
        }

        public override void OnEnter()
        {
            Debug.Log("Enter combatState");
            _enemy.EnterCombat();
            _view.Idle();
        }

        public override void OnExit()
        {
            Debug.Log("Exit combatState");
        }
    }
}