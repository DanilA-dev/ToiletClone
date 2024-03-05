using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Core.Menu
{
    public class WinMenu : BaseMenu
    {
        [SerializeField] private Button _toMainMenuButton;

        private void Start()
        {
            _toMainMenuButton.onClick.AddListener(ReturnToMainMenu);
        }

        private void ReturnToMainMenu()
        {
            _gameState.LoadScene(SceneType.Main);
        }

        public override MenuType MenuType => MenuType.WinMenu;
    }
}