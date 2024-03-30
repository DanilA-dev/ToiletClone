using Scriptables.Levels;
using UniRx;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private LevelData _defaultLevel;
        
        private LevelsContainer _levelsContainer;
        private GameState _gameState;

        [Inject]
        private void Construct(GameState gameState, LevelsContainer levelsContainer)
        {
            _gameState = gameState;
            _levelsContainer = levelsContainer;
        }

        private void Awake()
        {
            UpdateLevelStates();
            UpdateCurrentLevel();
            
            MessageBroker.Default.Receive<LevelUseSignal>()
                .Subscribe(_ => OnLevelSelect(_.Data)).AddTo(gameObject);
        }
    
        private void UpdateLevelStates()
        {
            for (int i = 1; i < _levelsContainer.LevelsData.Count; i++)
            {
                var lvl = _levelsContainer.LevelsData[i];
                
                if(lvl.LevelCompleteToOpen.State != LevelState.Completed)
                    lvl.SetState(LevelState.Closed);
                else if(lvl.LevelCompleteToOpen.State == LevelState.Completed)
                    lvl.SetState(LevelState.Open);
            }
        }

        private void UpdateCurrentLevel()
        {
            if (_defaultLevel.State != LevelState.Completed)
            {
                SetActiveLevel(_defaultLevel);
                return;
            }

            var newLevel = _levelsContainer.GetNextLevel();
            SetActiveLevel(newLevel);
        }

        private void OnLevelSelect(LevelData data)
        {
            switch (data.State)
            {
                case LevelState.Closed:
                case LevelState.Selected:
                    return;
                case LevelState.Completed:
                case LevelState.Open:
                   SetActiveLevel(data);
                    break;
            }
        }

        private void SetActiveLevel(LevelData data)
        {
            data.SetState(LevelState.Selected);
            _gameState.CurrentLevel.Value = data;
        }
    }
}