using UI.Core;
using UI.Core.Menu;
using UniRx;
using UnityEngine;

namespace Systems
{

    public class GameOverController : MonoBehaviour
    {
        public void Init()
        {
            GameState.EndGameState.Subscribe(OnGameEnd).AddTo(gameObject);
        }

        private void OnGameEnd(GameOverType type)
        {
            GameState.CurrentTab.Value = MenuType.WinMenu;
        }
    }
}