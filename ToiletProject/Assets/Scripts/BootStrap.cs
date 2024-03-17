using Systems;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    private SceneLoader _sceneLoader;
    
    private void Awake()
    {
        _sceneLoader = new SceneLoader(this);
        
        Application.targetFrameRate = 60;
        GameState.CurrentScene.Value = SceneType.MainMenu;
        DontDestroyOnLoad(gameObject);
    }
}
