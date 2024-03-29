using Systems;
using Systems.DataServiceSystem;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootInstaller : MonoInstaller
    {
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
            Application.targetFrameRate = 60;
        }
    }

}
