using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    public int mainMenuBuildIndex;
    public int charSelectBuildIndex;
    public int worldAreaBuildIndex;
    public int farmAreaBuildIndex;

    public static LevelLoading Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadScene(int sceneToLoad, LoadSceneMode loadMode)
    {
        SceneManager.LoadScene(sceneToLoad, loadMode);
    }

    public void LoadScene(int sceneToLoad, LoadSceneMode loadMode, int sceneToUnload)
    {
        SceneManager.LoadScene(sceneToLoad, loadMode);
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }

    public void UnloadScene(int sceneToUnload)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }
}
