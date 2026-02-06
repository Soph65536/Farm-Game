using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Menu optionsMenu;

    public void StartGame()
    {
        UIManager.Instance.LoadScene(UIManager.Instance.startBuildIndex, LoadSceneMode.Single, UIManager.Instance.mainMenuBuildIndex);
    }

    public void Options()
    {
        //if first time opening then find through uimanager
        if(optionsMenu == null) { optionsMenu = UIManager.Instance.FindMenuByName("options"); }
        UIManager.Instance.EnterMenu(optionsMenu);
    }

    public void QuitGame()
    {

    }
}
