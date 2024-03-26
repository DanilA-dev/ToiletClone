using System;
using System.Collections.Generic;
using System.Linq;
using Systems;
using Systems.EntityFactory;
using Core.Enemy;
using UnityEngine;

namespace Core.Level
{
    [System.Serializable]
    public class LevelStage
    {
        [SerializeField] private int _index;
        [SerializeField] private bool _isFinal;
        [SerializeField] private Transform _getPoint;
        [SerializeField] private List<Transform> _enemiesPositions = new List<Transform>();

        private EnemySpawner _enemySpawner;
        
        private List<HealthSystem> _enemiesHealth = new List<HealthSystem>();
        private List<EnemyController> _createdEnemies = new List<EnemyController>();
        public event Action<LevelStage> OnStageClear;

        #region Properties

        public bool IsClear { get; private set; }
        public Transform GetPoint => _getPoint;
        public List<EnemyController> CreatedEnemies => _createdEnemies;
        public int Index => _index;
        public bool IsFinal => _isFinal;

        #endregion
        
        public void Init(EnemySpawner _entitySpawnerHandler)
        {
            _enemySpawner = _entitySpawnerHandler;
        }

        public void Activate()
        {
            for (int i = 0; i < _enemiesPositions.Count; i++)
            {
                var pos = _enemiesPositions[i].position;
                var newEnemy = _enemySpawner.SpawnEntity();
                newEnemy.Agent.enabled = false;
                newEnemy.transform.position = pos;
                newEnemy.Agent.enabled = true;
                _createdEnemies.Add(newEnemy);
            }
            
            FindEnemiesHealthSystems();
            SubscribeToEnemyDeath();
        }
        
        private void SubscribeToEnemyDeath()
        {
            foreach (var eHealthSystem in _enemiesHealth)
                eHealthSystem.OnDie += CheckEnemiesStatus;
        }

        private void CheckEnemiesStatus()
        {
            if(_enemiesHealth.All(e => e.IsDead))
                Clear();
        }

        private void FindEnemiesHealthSystems()
        {
            _enemiesHealth.Clear();
            
            foreach (var enemy in _createdEnemies)
                _enemiesHealth.Add(enemy.Health);
        }
        
        private void Clear()
        {
            IsClear = true;
            OnStageClear?.Invoke(this);
        }
        
       
       
    }
}