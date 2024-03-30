using System;
using System.Collections;
using System.Collections.Generic;
using Data.PlayerStats;
using Data.Skins;
using Data.Upgrades;
using Data.User;
using Scriptables.Levels;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class DataInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStatsData _playerStatsData;
        [SerializeField] private SkinsContainer _skinsContainer;
        [SerializeField] private PlayerStatsUpgradeDataContainer _statsUpgradeData;
        [SerializeField] private LevelsContainer _levelsContainer;
        [SerializeField] private UserData _userData;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerStatsData>().FromInstance(_playerStatsData).AsSingle().NonLazy();
            Container.Bind<SkinsContainer>().FromInstance(_skinsContainer).AsSingle().NonLazy();
            Container.Bind<LevelsContainer>().FromInstance(_levelsContainer).AsSingle().NonLazy();
            Container.Bind<PlayerStatsUpgradeDataContainer>().FromInstance(_statsUpgradeData).AsSingle().NonLazy();
            Container.Bind<UserData>().FromInstance(_userData).AsSingle().NonLazy();

            QueueDatasForInject();
        }

        private void QueueDatasForInject()
        {
            foreach (var data in Datas())
                Container.QueueForInject(data);
        }

        private IEnumerable Datas()
        {
            return new List<ScriptableObject>
            {
                _playerStatsData,
                _userData
            };
        }
    }
}