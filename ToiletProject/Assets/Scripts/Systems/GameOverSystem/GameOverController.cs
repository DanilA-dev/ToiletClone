using System;
using Data.User;
using UI.Core;
using UI.Core.Menu;
using UniRx;
using UnityEngine;
using Zenject;

namespace Systems
{
    public enum GameOverType
    {
        Lose,
        Win
    }


    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private int _defaultGoldForWinValue = 100;
        
        private GameState _gameState;
        private ICurrencyProvider _currencyProvider;

        [Inject]
        private void Construct(GameState gameState, ICurrencyProvider currencyProvider)
        {
            _gameState = gameState;
            _currencyProvider = currencyProvider;
        }

        private void Awake()
        {
            _gameState.OnGameOver += OnGameEnd;
        }

        private void OnGameEnd(GameOverType type)
        {
            if (type == GameOverType.Win)
            {
                var goldCurrency = _currencyProvider.GetCurrencyByType(CurrencyType.Gold);
                goldCurrency?.Deposit(_defaultGoldForWinValue);
                _gameState.ChangeTab(MenuType.WinMenu);
            }
            else
                _gameState.ChangeTab(MenuType.LoseMenu);
        }
    }
}