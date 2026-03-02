using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public List<Menu> menus;
    public Menu currentMenu;

    public static UIManager Instance { get; private set; }

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

        menus = new List<Menu>();
        currentMenu = null;
    }

    public Menu FindMenuByName(string name)
    {
        foreach (Menu menu in menus)
        {
            if (menu.menuName == name) return menu;
        }

        return null; //if can't find then return null
    }

    public void EnterMenu(Menu newMenu)
    {
        if(currentMenu == newMenu || currentMenu != null) { return; }

        currentMenu = newMenu;
        currentMenu.Open();
    }

    public void EnterMenu(string menuName)
    {
        Menu newMenu = FindMenuByName(menuName);

        if (currentMenu == newMenu || currentMenu != null) { return; }

        currentMenu = newMenu;
        currentMenu.Open();
    }

    public void ExitMenu()
    {
        if (currentMenu == null) { return; }

        currentMenu.Close();
        currentMenu = null;
    }
}