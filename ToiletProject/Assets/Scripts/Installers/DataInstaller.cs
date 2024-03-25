using System;
using System.Collections;
using System.Collections.Generic;
using Data.PlayerStats;
using Data.User;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class DataInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStatsData _playerStatsData;
        [SerializeField] private UserData _userData;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerStatsData>().FromInstance(_playerStatsData).AsSingle().NonLazy();
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