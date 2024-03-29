using Systems;
using UnityEngine;

namespace Data.PlayerStats
{
    [System.Serializable]
    public class PlayerStatValue
    {
        
        [SerializeField] private int _currentValue;
        [field: SerializeField] public PlayerStatType Type { get; private set; }
        [field: SerializeField] public int MinValue { get; private set; }
        [field: SerializeField] public int MaxValue { get; private set; }
        
        public int CurrentValue
        {
            get => _currentValue;
            set => _currentValue = Mathf.Clamp(value, MinValue, MaxValue);
        }

        public void ChangeValue(int value) => CurrentValue += value;

        public void SetStat(int value) => CurrentValue = value;
    }
}