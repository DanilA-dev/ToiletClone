﻿using Core.Enemy;
using Core.Level;
using UnityEngine;

namespace Core.Player.PlayerStates
{
    public class PlayerCombatState : BasePlayerState
    {
        private EnemyController _currentEnemy;
        private readonly PlayerCombatSerializeData _combatSerializeData;
        
        public PlayerCombatState(PlayerView view, LevelStageHandler stageHandler,
            PlayerController playerController, PlayerCombatSerializeData serializeData) : base(view, stageHandler, playerController)
        {
            _combatSerializeData = serializeData;
        }

        public override void OnEnter()
        {
            _view.Combat();
        }

        public void SetEnemy(EnemyController enemy)
        {
            _currentEnemy = enemy;
        }
        
        public override void OnUpdate()
        {
            RotateTowardsEnemy();
        }

        private void RotateTowardsEnemy()
        {
            if(_currentEnemy == null)
                return;

            var speed = _combatSerializeData.RotateSpeed * Time.deltaTime;
            _playerController.transform.LookAt(_currentEnemy.transform);
        }

        public override void OnExit()
        {
        }
    }
}