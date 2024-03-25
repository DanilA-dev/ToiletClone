using System;
using UnityEngine.SceneManagement;

namespace Systems
{
    public enum SceneType
    {
        Loader = 0,
        MainMenu = 1,
        Level_1 = 2
    }
    
    public class SceneLoader : IDisposable
    {
        private readonly GameState _gameState;
        
        public SceneLoader(GameState gameState)
        {
            _gameState = gameState;
            _gameState.OnSceneChanged +=LoadScene;
            _gameState.OnGameRestarted += RestartScene;
        }
        
        private void LoadScene(SceneType scene)
        {
            if(SceneManager.GetActiveScene().name == scene.ToString())
                return;
            
            _gameState.CurrentStage.Value = 0;
            SceneManager.LoadScene(SceneType.Loader.ToString());
        }

        private void RestartScene()
        {
            _gameState.CurrentStage.Value = 0;
            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }

        public void Dispose()
        {
            _gameState.OnSceneChanged -=LoadScene;
        }
    }
}