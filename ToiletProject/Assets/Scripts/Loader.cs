using System.Collections;
using Systems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private Image _fillBar;

    private float _progress;
    
    private void Start()
    {
        StartCoroutine(LoadAsync(GameState.CurrentScene.Value));
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

            yield return null;
        }
        asyncOperation.allowSceneActivation = true;
    }

}
