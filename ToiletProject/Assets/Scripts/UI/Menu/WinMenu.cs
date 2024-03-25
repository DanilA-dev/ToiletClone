using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Core.Menu
{
    public class WinMenu : BaseMenu
    {
        [SerializeField] private Button _toMainMenuButton;

        public override MenuType MenuType => MenuType.WinMenu;
        private void Start()
        {
            _toMainMenuButton.onClick.AddListener(ReturnToMainMenu);
        }

        private void ReturnToMainMenu()
        {
            _gameState.ChangeScene(SceneType.MainMenu);
        }

    }
}