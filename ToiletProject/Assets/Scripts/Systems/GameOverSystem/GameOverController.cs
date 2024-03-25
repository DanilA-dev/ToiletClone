using System;
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

        private GameState _gameState;

        [Inject]
        private void Construct(GameState gameState)
        {
            _gameState = gameState;
        }

        private void Awake()
        {
            _gameState.OnGameOver += OnGameEnd;
        }

        private void OnGameEnd(GameOverType type)
        {
            _gameState.ChangeTab(type == GameOverType.Win ? MenuType.WinMenu 
                : MenuType.LoseMenu, MenuOpenSettings.FullSwitch);
        }
    }
}