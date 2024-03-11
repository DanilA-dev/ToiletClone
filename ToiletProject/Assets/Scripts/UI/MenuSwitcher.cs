using UI.Core.Menu;
using UnityEngine;
using System.Linq;
using UniRx;
using Systems;

namespace UI.Core
{
    public class MenuSwitcher : MonoBehaviour
    {
        
        [SerializeField] private BaseMenu[] _menus;
        
        public void Init(GameState gameState)
        {
            FindAllMenusOnScene(gameState);
            gameState.CurrentTab.Subscribe(SwitchMenu).AddTo(gameObject);
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
        
        private void FindAllMenusOnScene(GameState gameState)
        {
            if (_menus.Length <= 0)
                return;
            
            foreach (var menu in _menus)
                menu.Init(gameState);
        }


    }
}