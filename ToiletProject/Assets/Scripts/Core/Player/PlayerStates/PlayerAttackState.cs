using System;
using Systems;
using Core.Enemy;
using Core.Level;
using UnityEngine;

namespace Core.Player.PlayerStates
{
    public class PlayerAttackState : BasePlayerState
    {
        private EnemyController _currentEnemy;
        private HealthSystem _enemyHealthSystem;
        
        public PlayerAttackState(PlayerView view, LevelStageHandler stageHandler,
            PlayerController playerController)
             : base(view, stageHandler, playerController)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Enter attack state");
        }

        public void SetEnemy(EnemyController enemy)
        {
            _currentEnemy = enemy;
            _enemyHealthSystem = _currentEnemy.GetComponent<HealthSystem>();
        }
        private void AttackEnemy()
        {
            _view.Attack();
            _enemyHealthSystem.Damage(1);
        }
        
        public override void OnExit()
        {
            Debug.Log("Exit attack state");
        }
    }
}