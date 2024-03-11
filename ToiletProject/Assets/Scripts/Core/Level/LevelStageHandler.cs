using System.Collections.Generic;
using System.Linq;
using Systems;
using Core.Player;
using UniRx;
using UnityEngine;

namespace Core.Level
{
    public class LevelStageHandler : MonoBehaviour
    {
        [SerializeField] private List<LevelStage> _levelStages = new List<LevelStage>();

        private GameState _gameState;
        
        public void Init(PlayerController playerController, GameState gameState)
        {
            _gameState = gameState;
            
            foreach (var levelStage in _levelStages)
            {
                levelStage.Init(playerController);
                levelStage.OnStageClear += OnStageClear;
            }

            var firstStage = GetNextStage();
            firstStage.Activate();
        }
        public LevelStage GetCurrentStage() => _levelStages.Find(s => s.Index == _gameState.CurrentStage.Value);
        
        public LevelStage GetNextStage()
        {
            return _levelStages.OrderBy(s => s.Index).FirstOrDefault(s => !s.IsClear);
        }
        
        private void OnStageClear(LevelStage stage)
        {
            _gameState.IsStageClear.Value = true;
            _gameState.CurrentStage.Value++;
            GetNextStage()?.Activate();
            if (stage.IsFinal)
            {
                _gameState.IsGameOver.Value = true;
                _gameState.EndGameState.Value = GameOverType.Win;
            }
        }
      
    }
}