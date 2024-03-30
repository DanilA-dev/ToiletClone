using Systems;
using UnityEngine;

namespace Scriptables.Levels
{

    public enum LevelState
    {
        None = 0,
        Closed = 1,
        Open = 2,
        Selected = 3,
        Completed = 4
    }
    
    [CreateAssetMenu(menuName = "Data/Levels/New Level")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _levelIndex;
        [SerializeField] private LevelState _state;
        [SerializeField] private LevelData _levelCompleteToOpen;
        [SerializeField] private SceneType _levelSceneName;

        #region Properties

        public int LevelIndex => _levelIndex;
        public LevelState State => _state;
        public SceneType LevelSceneName => _levelSceneName;

        public LevelData LevelCompleteToOpen => _levelCompleteToOpen;

        #endregion

        public void SetState(LevelState state) => _state = state;

    }
}