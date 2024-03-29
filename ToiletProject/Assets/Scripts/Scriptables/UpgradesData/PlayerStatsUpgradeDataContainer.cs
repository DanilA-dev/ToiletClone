using System.Collections.Generic;
using System.Linq;
using Systems;
using UnityEngine;

namespace Data.Upgrades
{
    [CreateAssetMenu(menuName = "Data/Player Upgrades Container")]
    public class PlayerStatsUpgradeDataContainer : ScriptableObject
    {
        [SerializeField] private List<PlayerStatUpgradeData> _upgrades;

        public PlayerStatUpgradeData GetStatUpgradeData(PlayerStatType type)
            => _upgrades.Find(u => u.Type == type);

    }
}