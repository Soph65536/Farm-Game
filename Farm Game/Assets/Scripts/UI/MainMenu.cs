using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        UIManager.Instance.LoadScene(UIManager.Instance.startBuildIndex, LoadSceneMode.Single, UIManager.Instance.mainMenuBuildIndex);
    }

    public void Options()
    {
        UIManager.Instance.EnterMenu("options");
    }

    public void QuitGame()
    {

    }
}
