using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    [SerializeField]
    private GameObject _loaderCanves;
    [SerializeField]
    private Slider _progressBar;


    private void Awake()
    {
        instance = this;
    }

    public async void LoadScene(string sceneName)
    {

        var scene = SceneManager.LoadSceneAsync(sceneName);

        scene.allowSceneActivation = false;
        _loaderCanves.SetActive(true);
        do
        {
            await System.Threading.Tasks.Task.Delay(1000);
            _progressBar.value = scene.progress;
        } while (scene.progress < 0.9f);

        await System.Threading.Tasks.Task.Delay(2500);
        _loaderCanves.SetActive(false);
        scene.allowSceneActivation = true;

    }
}
