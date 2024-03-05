using UI.Core.Menu;
using UnityEngine;
using System.Linq;
using Systems;

namespace UI.Core
{
    public class MenuSwitcher : MonoBehaviour
    {
        private static MenuSwitcher _instance;
        
        private BaseMenu[] _menus;
        
        public void Init(GameState gameState)
        {
            _instance = this;
            FindAllMenusOnScene(gameState);
        }

        public static void SwitchMenu(MenuType menuType)
        {
            if(_instance._menus == null)
                return;

            foreach (var menu in _instance._menus)
            {
                var state = menu.MenuType == menuType;
                menu.gameObject.SetActive(state);
            }
        }

        public static void OpenMenu(MenuType menuType)
        {
            if(_instance._menus == null)
                return;

            var menuToOpen = _instance._menus.FirstOrDefault(m => m.MenuType == menuType);
            menuToOpen?.gameObject.SetActive(true);
        }
        
        private void FindAllMenusOnScene(GameState gameState)
        {
            _menus = FindObjectsOfType<BaseMenu>();

            if (_instance._menus == null)
                return;
            
            foreach (var menu in _instance._menus)
                menu.Init(gameState);
        }

        public MenuSwitcher Instance() => _instance;

    }
}