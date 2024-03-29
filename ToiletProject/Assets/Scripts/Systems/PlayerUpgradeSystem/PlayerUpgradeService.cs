using System;
using Data;
using Data.PlayerStats;
using Data.Upgrades;
using UniRx;
using UnityEngine;
using Zenject;

namespace Systems
{
    public enum PlayerStatType
    {
        Damage,
        MaxHealth
    }
    
    public class PlayerUpgradeService : MonoBehaviour
    {

        private PlayerStatsData _playerStatsData;
        private PlayerStatsUpgradeDataContainer _upgradesContainer;
        private ICurrencyProvider _currencyProvider;

        [Inject]
        private void Construct(PlayerStatsData playerStatsData, ICurrencyProvider currencyProvider,
            PlayerStatsUpgradeDataContainer upgradeDataContainer)
        {
            _playerStatsData = playerStatsData;
            _currencyProvider = currencyProvider;
            _upgradesContainer = upgradeDataContainer;
        }

        private void Start()
        {
            MessageBroker.Default.Receive<PlayerUpgradeSingal>()
                .Subscribe(_ => UpgradePlayerStats(_.StatType)).AddTo(gameObject);
        }

        private void UpgradePlayerStats(PlayerStatType type)
        {
            switch (type)
            {
                case PlayerStatType.Damage:
                    TryUpgradeStat(PlayerStatType.Damage);
                    break;
                case PlayerStatType.MaxHealth:
                    TryUpgradeStat(PlayerStatType.MaxHealth);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void TryUpgradeStat(PlayerStatType type)
        {
            var stat = _playerStatsData.GetStatValueByType(type);
            var upgrade = _upgradesContainer.GetStatUpgradeData(type);
            var currency = _currencyProvider.GetCurrencyByType(upgrade.CurrencType);
            
            if (upgrade != null && currency.TryWithdraw(upgrade.UpgradeCost))
                stat.ChangeValue(upgrade.UpgradeValue);
            
        }
        
        
    }
}