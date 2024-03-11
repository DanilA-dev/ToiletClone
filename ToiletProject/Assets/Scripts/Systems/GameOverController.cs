using UI.Core;
using UI.Core.Menu;
using UniRx;
using UnityEngine;

namespace Systems
{

    public class GameOverController : MonoBehaviour
    {
        private GameState _gameState;
        public void Init(GameState gameState)
        {
            _gameState = gameState;
            gameState.EndGameState.Subscribe(OnGameEnd).AddTo(gameObject);
        }

        private void OnGameEnd(GameOverType type)
        {
            Debug.Log("End");
            var menu = type == GameOverType.Win ? MenuType.WinMenu : MenuType.LoseMenu;
            _gameState.CurrentTab.Value = menu;
        }
    }
}