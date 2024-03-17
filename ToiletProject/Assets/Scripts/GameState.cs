using System;
using UI.Core.Menu;
using UniRx;

namespace Systems
{
    public enum GameOverType
    {
        Lose,
        Win
    }
    
    public static class GameState
    {
        public static IntReactiveProperty CurrentStage = new IntReactiveProperty();
        public static ReactiveProperty<MenuType> CurrentTab = new ReactiveProperty<MenuType>();
        public static ReactiveProperty<GameOverType> EndGameState = new ReactiveProperty<GameOverType>();
        public static BoolReactiveProperty IsGameOver = new BoolReactiveProperty();
        public static ReactiveProperty<SceneType> CurrentScene = new ReactiveProperty<SceneType>();
        public static BoolReactiveProperty IsStageClear = new BoolReactiveProperty();

        public static event Action OnGameRestarted;

        public static void RestartGame()
        {
            OnGameRestarted?.Invoke();
        }

    }
}