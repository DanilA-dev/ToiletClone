using System;
using System.Collections.Generic;
using System.Linq;
using Systems;
using Core.Enemy;
using Core.Level;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Player.PlayerStates
{
    public class TargetController : MonoBehaviour
    {
        private LevelStageHandler _levelStageHandler;
        private List<EnemyController> _activeEnemies;
        private GameState _gameState;

        public event Action<EnemyController> OnTargetUpdate;
        
        public void Init(GameState gameState, LevelStageHandler levelStageHandler)
        {
            _gameState = gameState;
            _levelStageHandler = levelStageHandler;
            _gameState.CurrentStage.Subscribe(_ => UpdateActiveEnemies()).AddTo(gameObject);
            
            _activeEnemies = _levelStageHandler.GetNextStage().Enemies;
        }

        private void UpdateActiveEnemies()
        {
            if(_activeEnemies != null)
                foreach (var enemy in _activeEnemies)
                    enemy.Health.OnDie -= CheckEnemiesDeath;
            
            _activeEnemies = _levelStageHandler.GetNextStage().Enemies;
            if(_activeEnemies == null)
                return;
            
            foreach (var enemy in _activeEnemies)
                enemy.Health.OnDie += CheckEnemiesDeath;
        }

        private void CheckEnemiesDeath()
        {
            OnTargetUpdate?.Invoke(GetTarget());
        }

        public EnemyController GetTarget()
        {
            var aliveEnemies = _activeEnemies.Where(e => !e.Health.IsDead).ToList();
            var randIndex = Random.Range(0, aliveEnemies.Count);
            return aliveEnemies[randIndex];
        }

    }
}