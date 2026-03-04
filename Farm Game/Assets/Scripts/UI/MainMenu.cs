using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        LevelLoading.Instance.LoadScene(LevelLoading.Instance.charSelectBuildIndex, LoadSceneMode.Single, LevelLoading.Instance.mainMenuBuildIndex);
    }

    public void Options()
    {
        UIManager.Instance.EnterMenu("options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
