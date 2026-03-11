using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuOpen : MonoBehaviour
{
    private Menu thisMenu;
    [SerializeField] private string inputAction;

    private void Awake()
    {
        thisMenu = GetComponent<Menu>();
    }

    private void OnEnable()
    {
        Invoke(nameof(EnableInput), 0.5f); //unity likes to not have player vars declared yet for some reason
    }

    private void EnableInput()
    {
        Player.Instance.input.actions[inputAction].performed += ToggleMenu;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions[inputAction].performed -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        if(UIManager.Instance.currentMenu == thisMenu) { UIManager.Instance.ExitMenu(); }
        else { UIManager.Instance.EnterMenu(thisMenu); }
    }

    public void OpenMenu()
    {
        UIManager.Instance.EnterMenu(thisMenu);
    }
}
