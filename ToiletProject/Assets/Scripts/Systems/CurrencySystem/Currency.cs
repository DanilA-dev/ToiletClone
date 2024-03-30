using System;
using UnityEngine;

namespace Systems
{
    public enum CurrencyType
    {
        Gold = 0
    }
    
    [System.Serializable]
    public class Currency
    {
        [field: SerializeField] public CurrencyType Type { get; private set; }
        [field: SerializeField] public int DefaultValue { get; private set; }
        [field: SerializeField] public int CurrentValue { get; private set; }

        public event Action<int> OnValueChanged; 
        

        public Currency(CurrencyType type, int defaultValue = 50)
        {
            Type = type;
            DefaultValue = defaultValue;
        }

        public bool TryWithdraw(int withdrawValue)
        {
            if (CurrentValue - withdrawValue >= 0)
            {
                CurrentValue -= withdrawValue;
                OnValueChanged?.Invoke(CurrentValue);
                return true;
            }

            return false;
        }

        public void Deposit(int value)
        {
            CurrentValue += value;
            OnValueChanged?.Invoke(CurrentValue);
        }

        public void SetValue(int value)
        {
            CurrentValue = value;
            OnValueChanged?.Invoke(CurrentValue);
        }
    }
}