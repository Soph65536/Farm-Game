using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void Options()
    {
        UIManager.Instance.ExitMenu();
        UIManager.Instance.EnterMenu("options");
    }

    public void MainMenu()
    {
        LevelLoading.Instance.LoadScene(LevelLoading.Instance.mainMenuBuildIndex, LoadSceneMode.Single, LevelLoading.Instance.worldAreaBuildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
