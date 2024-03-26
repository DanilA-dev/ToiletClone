using Systems;
using Core.Enemy;
using Core.Level;
using Core.Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private GameOverController _gameOverController;
        [SerializeField] private LevelStageHandler _levelStageHandler;
        [SerializeField] private PlayerActionReceiver _actionReceiver;

        public override void InstallBindings()
        {
            Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle().NonLazy();
            Container.Bind<PlayerSpawner>().FromInstance(_playerSpawner).AsSingle().NonLazy();
            Container.Bind<GameOverController>().FromInstance(_gameOverController).AsSingle().NonLazy();
            Container.Bind<ILevelStageHandler>().To<LevelStageHandler>().FromInstance(_levelStageHandler).AsSingle()
                .NonLazy();
            Container.Bind<PlayerActionReceiver>().FromInstance(_actionReceiver).AsSingle().NonLazy();
        }
    }
}