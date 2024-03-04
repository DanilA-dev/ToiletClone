using System;
using System.Collections.Generic;
using System.Linq;
using Systems;
using Core.Enemy;
using Core.Player;
using UnityEngine;

namespace Core.Level
{
    [System.Serializable]
    public class LevelStage
    {
        [SerializeField] private int _index;
        [SerializeField] private bool _isFinal;
        [SerializeField] private Transform _getPoint;
        [SerializeField] private List<EnemyController> _enemies = new List<EnemyController>();

        private List<HealthSystem> _enemiesHealth = new List<HealthSystem>();
        public event Action<LevelStage> OnStageClear;

        public void Init(PlayerController playerController)
        {
            _enemies.ForEach(e => e.Init(playerController));
            FindEnemiesHealthSystems();
            SubscribeToEnemyDeath();
        }

        public void Activate()
        {
            foreach (var enemy in _enemies)
                enemy.gameObject.SetActive(true);
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
            foreach (var enemy in _enemies)
            {
                var healthSystem = enemy.GetComponent<HealthSystem>();
                if (healthSystem != null)
                    _enemiesHealth.Add(healthSystem);
            }
        }
        
        private void Clear()
        {
            IsClear = true;
            OnStageClear?.Invoke(this);
        }
        
        #region Properties

        public bool IsClear { get; private set; }

        public Transform GetPoint => _getPoint;

        public List<EnemyController> Enemies => _enemies;
        public int Index => _index;
        public bool IsFinal => _isFinal;

        #endregion
       
    }
}