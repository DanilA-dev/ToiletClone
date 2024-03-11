using UI.Core.Menu;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public enum GameOverType
    {
        Lose,
        Win
    }
    
    public enum SceneType
    {
        Main = 0,
        Level_1 = 1
    }
    
    public class GameState
    {
        public IntReactiveProperty CurrentStage = new IntReactiveProperty();
        public ReactiveProperty<MenuType> CurrentTab = new ReactiveProperty<MenuType>();
        public ReactiveProperty<GameOverType> EndGameState = new ReactiveProperty<GameOverType>();
        public BoolReactiveProperty IsGameOver = new BoolReactiveProperty();
        public BoolReactiveProperty IsStageClear = new BoolReactiveProperty();
        
        public void LoadScene(SceneType scene)
        {
            CurrentStage.Value = 0;
            SceneManager.LoadScene((int) scene);
        }

        public void RestartScene()
        {
            CurrentStage.Value = 0;
            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
        
    }
}