using Systems;
using UnityEngine;
using Zenject;

namespace UI.Core.Menu
{
    public enum MenuType
    {
        None = 0,
        MainMenu = 1,
        CoreMenu = 2,
        WinMenu = 3,
        LoseMenu = 4,
        ShopMenu = 5,
        SkinsMenu = 7,
        SettingsMenu = 8,
        LevelsMenu = 9
    }
    
    public abstract class BaseMenu : MonoBehaviour
    {
        protected GameState _gameState;
        public abstract MenuType MenuType { get; }

        [Inject]
        private void Construct(GameState gameState)
        {
            _gameState = gameState;
        }
        
    }
}