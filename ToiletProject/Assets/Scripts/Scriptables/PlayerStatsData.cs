using System.Collections.Generic;
using Systems;
using UnityEngine;

namespace Data.PlayerStats
{
    [CreateAssetMenu(menuName = "Data/PlayerData")]
    public class PlayerStatsData : ScriptableObject
    {
        [SerializeField] private List<PlayerStatValue> _playerStats;
       
        public List<PlayerStatValue> PlayerStats => _playerStats;

        public PlayerStatValue GetStatValueByType(PlayerStatType type)
            => _playerStats.Find(p => p.Type == type);
    }
}
