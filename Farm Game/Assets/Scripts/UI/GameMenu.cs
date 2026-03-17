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
        //when open main menu destroy all big game stuff
        UIManager.Instance.DestroyAllMenus();
        Destroy(UIManager.Instance.gameObject);
        Destroy(StatManager.Instance.gameObject);
        Destroy(QuestManager.Instance.gameObject);
        Destroy(Player.Instance.gameObject);
        Destroy(CameraController.Instance.gameObject);


        LevelLoading.Instance.LoadScene(LevelLoading.Instance.mainMenuBuildIndex, LoadSceneMode.Single, LevelLoading.Instance.worldAreaBuildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
