using System.Collections.Generic;
using System.Linq;
using Systems;
using Systems.EntityFactory;
using UnityEngine;
using Zenject;

namespace Core.Level
{
    public class LevelStageHandler : MonoBehaviour, ILevelStageHandler
    {
        [SerializeField] private List<LevelStage> _levelStages = new List<LevelStage>();

        private GameState _gameState;
        private EntitySpawner _entitySpawner;
        
        [Inject]
        private void Construct(GameState gameState, EntitySpawner entitySpawner)
        {
            _gameState = gameState;
            _entitySpawner = entitySpawner;
        }

        private void Awake()
        {
            Init();
        }

        private void OnDestroy()
        {
            foreach (var levelStage in _levelStages)
                levelStage.OnStageClear -= OnStageClear;
        }

        private void Init()
        {
            foreach (var levelStage in _levelStages)
            {
                levelStage.Init(_entitySpawner);
                levelStage.OnStageClear += OnStageClear;
            }

            var firstStage = GetNextStage();
            firstStage.Activate();
        }
        
        public LevelStage GetNextStage()
        {
            return _levelStages.OrderBy(s => s.Index).FirstOrDefault(s => !s.IsClear);
        }
        
        private void OnStageClear(LevelStage stage)
        {
            _gameState.CurrentStage.Value++;
            GetNextStage()?.Activate();
            if (!stage.IsFinal)
                return;
            
            _gameState.SetGameOver(GameOverType.Win);
        }
      
    }
}