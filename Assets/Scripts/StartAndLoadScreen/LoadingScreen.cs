using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace StartAndLoadScreen
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject currentScene;
        [SerializeField] private GameObject loagingScreen;
        [SerializeField] private Slider loadingBarFill;

        public void LoadingScene(int sceneId)
        {
            StartCoroutine(LoadingSceneAsync(sceneId));
        }

        IEnumerator LoadingSceneAsync(int sceneId)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
            currentScene.SetActive(false);
            loagingScreen.SetActive(true);
            while (!operation.isDone)
            {
                float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
                loadingBarFill.value = progressValue;
                yield return null;
            }
        }
    }
}