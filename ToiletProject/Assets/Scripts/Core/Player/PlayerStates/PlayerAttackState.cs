using System;
using Systems;
using Core.Enemy;
using Core.Level;
using Data;
using UniRx;
using UnityEngine;

namespace Core.Player.PlayerStates
{
    public class PlayerAttackState : BasePlayerState
    {
        private EnemyController _currentEnemy;
        private PlayerData _data;
        
        public PlayerAttackState(PlayerView view, LevelStageHandler stageHandler,
            PlayerController playerController, PlayerData data)
             : base(view, stageHandler, playerController)
        {
            _data = data;
        }

        public override void OnEnter()
        {
            AttackEnemy();
        }

        public void SetEnemy(EnemyController enemy)
        {
            _currentEnemy = enemy;
        }
        private void AttackEnemy()
        {
            _view.Attack();
            _currentEnemy.Health.Damage(_data.Damage);
        }
        
        public override void OnExit()
        {
        }
    }
}