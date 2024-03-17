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

        
        public void Init(PlayerController playerController)
        {
            
            foreach (var levelStage in _levelStages)
            {
                levelStage.Init(playerController);
                levelStage.OnStageClear += OnStageClear;
            }

            var firstStage = GetNextStage();
            firstStage.Activate();
        }
        public LevelStage GetCurrentStage() => _levelStages.Find(s => s.Index == GameState.CurrentStage.Value);
        
        public LevelStage GetNextStage()
        {
            return _levelStages.OrderBy(s => s.Index).FirstOrDefault(s => !s.IsClear);
        }
        
        private void OnStageClear(LevelStage stage)
        {
            GameState.IsStageClear.Value = true;
            GameState.CurrentStage.Value++;
            GetNextStage()?.Activate();
            if (stage.IsFinal)
            {
                GameState.IsGameOver.Value = true;
                GameState.EndGameState.Value = GameOverType.Win;
            }
        }
      
    }
}