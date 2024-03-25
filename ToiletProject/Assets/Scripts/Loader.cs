using System.Collections;
using Systems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Loader : MonoBehaviour
{
    [SerializeField] private Image _fillBar;

    private float _progress;
    private GameState _gameState;
    
    [Inject]
    private void Construct(GameState gameState)
    {
        _gameState = gameState;
    }

    
    private void Start()
    {
        StartCoroutine(LoadAsync(_gameState.LoadedScene));
    }

    private void Update()
    {
        _fillBar.fillAmount = Mathf.MoveTowards(_fillBar.fillAmount, _progress, Time.deltaTime * 3);
    }
   
    private IEnumerator LoadAsync(SceneType sceneType)
    {
        yield return null;
        var asyncOperation = SceneManager.LoadSceneAsync(sceneType.ToString());
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            _progress = asyncOperation.progress;
            if (asyncOperation.progress >= 0.9f)
                break;

            yield return new WaitForSeconds(0.5f);
        }
        asyncOperation.allowSceneActivation = true;
    }

}
