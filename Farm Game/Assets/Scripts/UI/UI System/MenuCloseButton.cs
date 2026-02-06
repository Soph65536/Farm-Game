using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCloseButton : MonoBehaviour
{
    public void ExitMenu()
    {
        UIManager.Instance.ExitMenu();
    }
}
