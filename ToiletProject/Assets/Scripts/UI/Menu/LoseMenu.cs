using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Core.Menu
{
    public class LoseMenu : BaseMenu
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _returnToMenuButton;

        public override MenuType MenuType => MenuType.LoseMenu;
        
        private void Start()
        {
            _returnToMenuButton.onClick.AddListener(ReturnToMainMenu);
            _restartButton.onClick.AddListener(RestartLevel);
        }

        private void ReturnToMainMenu()
        {
            _gameState.ChangeScene(SceneType.MainMenu);
        }

        private void RestartLevel()
        {
            _gameState.RestartGame();
        }

    }
}