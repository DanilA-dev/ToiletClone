using System;
using Systems;
using Systems.DataServiceSystem;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootInstaller : MonoInstaller
    {
        private SaveDataController _saveDataController;
        
        public override void InstallBindings()
        {
            Container.Bind<GameState>().FromNew().AsSingle().NonLazy();
            Container.Bind<IDataService>().To<JSONDataService>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SaveDataController>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneLoader>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CurrencyProvider>().FromNew().AsSingle().NonLazy();
        }

        private void Awake()
        {
            _saveDataController = Container.Resolve<SaveDataController>();
            Application.targetFrameRate = 60;
             _saveDataController.Load();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            _saveDataController.Save();
        }

        private void OnApplicationQuit()
        {
            _saveDataController.Save();
        }
    }

}
