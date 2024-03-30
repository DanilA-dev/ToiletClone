using Systems;
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
            Container.BindInterfacesAndSelfTo<SaveDataController>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneLoader>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CurrencyProvider>().FromNew().AsSingle().NonLazy();
        }

        private void Awake()
        {
            Application.targetFrameRate = 60;
            _saveDataController = Container.Resolve<SaveDataController>();
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
