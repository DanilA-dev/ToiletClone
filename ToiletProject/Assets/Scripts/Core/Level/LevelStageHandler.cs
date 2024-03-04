using System.Collections.Generic;
using System.Linq;
using Core.Player;
using UnityEngine;

namespace Core.Level
{
    public class LevelStageHandler : MonoBehaviour
    {
        [SerializeField] private int _currentStageIndex;
        [SerializeField] private List<LevelStage> _levelStages = new List<LevelStage>();

        public void Init(PlayerController playerController)
        {
            foreach (var levelStage in _levelStages)
            {
                levelStage.Init(playerController);
                levelStage.OnStageClear += OnStageClear;
            }
        }

        public LevelStage GetCurrentStage() => _levelStages.Find(s => s.Index == _currentStageIndex);
        
        public LevelStage GetNextStage()
        {
            return _levelStages.OrderBy(s => s.Index).FirstOrDefault(s => !s.IsClear);
        }
        
        private void OnStageClear(LevelStage stage)
        {
            _currentStageIndex++;
            if (stage.IsFinal)
            {
                //Win signal
            }
        }
      
    }
}