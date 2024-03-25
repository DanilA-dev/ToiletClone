using Systems;
using Systems.EntityFactory;
using Core.Level;
using Core.Player;
using Core.Player.PlayerStates;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private EntitySpawner _entitySpawner;
        [SerializeField] private TargetController _targetController;
        [SerializeField] private GameOverController _gameOverController;
        [SerializeField] private LevelStageHandler _levelStageHandler;
        [SerializeField] private PlayerActionReceiver _actionReceiver;

        public override void InstallBindings()
        {
            _entitySpawner.Init();
            Container.Bind<EntitySpawner>().FromInstance(_entitySpawner).AsSingle().NonLazy();
            Container.Bind<PlayerController>().FromInstance(_entitySpawner.SpawnPlayer()).AsSingle().NonLazy();
            
            Container.Bind<TargetController>().FromInstance(_targetController).AsSingle().NonLazy();
            Container.Bind<GameOverController>().FromInstance(_gameOverController).AsSingle().NonLazy();
            Container.Bind<ILevelStageHandler>().To<LevelStageHandler>().FromInstance(_levelStageHandler).AsSingle()
                .NonLazy();
            Container.Bind<PlayerActionReceiver>().FromInstance(_actionReceiver).AsSingle().NonLazy();
        }
    }
}