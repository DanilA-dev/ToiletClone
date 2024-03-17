using UniRx;
using UnityEngine.SceneManagement;

namespace Systems
{
    public enum SceneType
    {
        Loader = 0,
        MainMenu = 1,
        Level_1 = 2
    }
    
    public class SceneLoader
    {
        public SceneLoader(BootStrap bootStrap)
        {
            GameState.CurrentScene.Subscribe(LoadScene).AddTo(bootStrap);
            GameState.OnGameRestarted += RestartScene;
        }
        
        private void LoadScene(SceneType scene)
        {
            if(SceneManager.GetActiveScene().name == scene.ToString())
                return;
            
            GameState.CurrentStage.Value = 0;
            SceneManager.LoadScene(SceneType.Loader.ToString());
        }

        private void RestartScene()
        {
            GameState.CurrentStage.Value = 0;
            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
    }
}