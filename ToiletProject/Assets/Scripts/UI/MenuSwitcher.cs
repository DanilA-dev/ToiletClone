using System;
using UI.Core.Menu;
using UnityEngine;
using System.Linq;
using Systems;
using Zenject;

namespace UI.Core
{
    public enum MenuOpenSettings
    {
        FullSwitch = 0,
        OpenOnTop = 1
    }
    
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private BaseMenu[] _menus;

        private GameState _gameState;
        
        [Inject]
        private void Construct(GameState gameState)
        {
            _gameState = gameState;
        }

        private void Awake()
        {
            _gameState.OnTabChanged += ChangeTab;
        }

        private void OnDestroy()
        {
            _gameState.OnTabChanged -= ChangeTab;
        }

        private void ChangeTab(MenuType menu, MenuOpenSettings settings)
        {
            switch (settings)
            {
                case MenuOpenSettings.FullSwitch:
                    SwitchMenu(menu);
                    break;
                case MenuOpenSettings.OpenOnTop:
                    OpenMenu(menu);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(settings), settings, null);
            }
        }

        private void SwitchMenu(MenuType menuType)
        {
            foreach (var menu in _menus)
            {
                var state = menu.MenuType == menuType;
                menu.gameObject.SetActive(state);
            }
        }

        private void OpenMenu(MenuType menuType)
        {
            if (_menus.Length <= 0)
                return;

            var menuToOpen = _menus.FirstOrDefault(m => m.MenuType == menuType);
            menuToOpen?.gameObject.SetActive(true);
        }


    }
}