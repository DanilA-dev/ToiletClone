using System;
using Data;
using Data.PlayerStats;
using UniRx;
using UnityEngine;
using Zenject;

namespace Systems
{
    public enum PlayerUpgradeType
    {
        Damage,
        Health
    }
    
    public class PlayerUpgradeService : MonoBehaviour
    {

        private PlayerStatsData _playerStatsData;

        [Inject]
        private void Construct(PlayerStatsData playerStatsData)
        {
            _playerStatsData = playerStatsData;
        }

        private void Start()
        {
            MessageBroker.Default.Receive<PlayerUpgradeSingal>()
                .Subscribe(_ => UpgradePlayerStats(_.UpgradeType)).AddTo(gameObject);
        }

        private void UpgradePlayerStats(PlayerUpgradeType type)
        {
            switch (type)
            {
                case PlayerUpgradeType.Damage:
                    _playerStatsData.IncreaseDamage();
                    break;
                case PlayerUpgradeType.Health:
                    _playerStatsData.IncreaseMaxHealth();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}