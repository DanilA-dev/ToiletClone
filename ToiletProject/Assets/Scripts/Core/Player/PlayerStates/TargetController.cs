using System;
using System.Collections.Generic;
using System.Linq;
using Systems;
using Core.Enemy;
using Core.Level;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Player.PlayerStates
{
    public class TargetController : MonoBehaviour
    {
        private ILevelStageHandler _levelStageHandler;
        private GameState _gameState;
        private List<EnemyController> _activeEnemies;

        public event Action<EnemyController> OnTargetUpdate;

        [Inject]
        private void Construct(GameState gameState,ILevelStageHandler levelStageHandler)
        {
            _gameState = gameState;
            _levelStageHandler = levelStageHandler;
        }

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            _gameState.CurrentStage.Subscribe(_ => UpdateActiveEnemies()).AddTo(gameObject);
            _activeEnemies = _levelStageHandler.GetNextStage().CreatedEnemies;
        }

        private void UpdateActiveEnemies()
        {
            if(_activeEnemies != null)
                foreach (var enemy in _activeEnemies)
                    enemy.Health.OnDie -= CheckEnemiesDeath;
            
            _activeEnemies = _levelStageHandler.GetNextStage().CreatedEnemies;
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