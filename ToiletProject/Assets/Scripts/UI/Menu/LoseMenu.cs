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
            _gameState.LoadScene(SceneType.Main);
        }

        private void RestartLevel()
        {
            _gameState.RestartScene();
        }

        public override MenuType MenuType => MenuType.LoseMenu;
    }
}