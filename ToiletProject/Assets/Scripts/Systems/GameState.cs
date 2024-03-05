using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public enum SceneType
    {
        Main = 0,
        Level_1 = 1
    }
    
    [CreateAssetMenu(menuName = "GameState")]
    public class GameState : ScriptableObject
    {
        public IntReactiveProperty CurrentLevel = new IntReactiveProperty();
        public IntReactiveProperty CurrentStage = new IntReactiveProperty();
        
        public void LoadScene(SceneType scene)
        {
            CurrentStage.Value = 0;
            SceneManager.LoadScene((int) scene);
        }

        public void LoadCurrentLevel()
        {
            CurrentStage.Value = 0;
            SceneManager.LoadScene(CurrentLevel.Value);
        }

        public void RestartScene()
        {
            CurrentStage.Value = 0;
            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
        
    }
}