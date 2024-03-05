using Systems;
using UnityEngine;

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
        SettingsMenu = 8
    }
    
    public abstract class BaseMenu : MonoBehaviour
    {
        protected GameState _gameState;
        
        public abstract MenuType MenuType { get; }

        public void Init(GameState gameState) => _gameState = gameState;

    }
}