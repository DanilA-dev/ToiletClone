using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Core.Menu
{
    public class LoseMenu : BaseMenu
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _returnToMenuButton;

        private void Start()
        {
            _returnToMenuButton.onClick.AddListener(ReturnToMainMenu);
            _restartButton.onClick.AddListener(RestartLevel);
        }

        private void ReturnToMainMenu()
        {
            GameState.CurrentScene.Value = SceneType.MainMenu;
        }

        private void RestartLevel()
        {
            GameState.RestartGame();
        }

        public override MenuType MenuType => MenuType.LoseMenu;
    }
}