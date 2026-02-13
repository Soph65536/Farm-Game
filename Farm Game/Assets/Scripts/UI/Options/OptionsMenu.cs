using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject displayUI;
    [SerializeField] private GameObject controlsUI;
    [SerializeField] private GameObject gameplayUI;

    void Awake()
    {
        OpenDisplay();
    }

    public void OpenDisplay()
    {
        displayUI.SetActive(true);
        controlsUI.SetActive(false);
        gameplayUI.SetActive(false);
    }

    public void OpenControls()
    {
        displayUI.SetActive(false);
        controlsUI.SetActive(true);
        gameplayUI.SetActive(false);
    }

    public void OpenGameplay()
    {
        displayUI.SetActive(false);
        controlsUI.SetActive(false);
        gameplayUI.SetActive(true);
    }
}
