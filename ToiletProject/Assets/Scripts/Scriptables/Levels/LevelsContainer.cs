using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scriptables.Levels
{
    [CreateAssetMenu(menuName = "Data/Levels/Levels Container")]
    public class LevelsContainer : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levelsData;

        public List<LevelData> LevelsData => _levelsData;

        public LevelData GetNextLevel()
        {
            var lvl = _levelsData.OrderBy(l => l.LevelIndex)
                .FirstOrDefault(l => l.State == LevelState.Open);

            return lvl;
        }
      
    }
}