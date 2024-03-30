using Systems;
using UnityEngine;

namespace Data.Upgrades
{
    
    [CreateAssetMenu(menuName = "Data/Player Upgrades/New Upgrade")]
    public class PlayerStatUpgradeData : ScriptableObject
    {
        [field: SerializeField] public PlayerStatType Type { get; private set; }
        [field: SerializeField] public int UpgradeValue { get; private set; }
        [field: SerializeField] public CurrencyType CurrencType { get; private set; }
        [field: SerializeField] public int UpgradeCost { get; private set; }
    }
}