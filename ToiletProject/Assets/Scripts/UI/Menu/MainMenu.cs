using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Core.Menu
{
    public class MainMenu : BaseMenu
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _upgradeAttackButton;
        [SerializeField] private Button _upgradeHealthBuitton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _skinsButton;
        [SerializeField] private Button _shopButton;
        
        public override MenuType MenuType => MenuType.MainMenu;

        private void Start()
        {
            _playButton?.onClick.AddListener(StartCore);
            _upgradeAttackButton?.onClick.AddListener(UpgradeAttack);
            _upgradeHealthBuitton?.onClick.AddListener(UpgradeHealth);
            _settingsButton?.onClick.AddListener(OpenSettings);
            _skinsButton?.onClick.AddListener(OpenSkins);
            _shopButton?.onClick.AddListener(OpenShop);
        }

        private void StartCore()
        {
            _gameState.LoadCurrentLevel();
        }
        
        private void OpenShop()
        {
            MenuSwitcher.SwitchMenu(MenuType.ShopMenu);
        }

        private void OpenSkins()
        {
            MenuSwitcher.SwitchMenu(MenuType.SkinsMenu);
        }

        private void OpenSettings()
        {
            MenuSwitcher.OpenMenu(MenuType.SettingsMenu);
        }

        private void UpgradeHealth()
        {
            
        }

        private void UpgradeAttack()
        {
            
        }

    }
}