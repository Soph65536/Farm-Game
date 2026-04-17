using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject displayUI;
    [SerializeField] private GameObject audioUI;
    [SerializeField] private GameObject controlsUI;
    [SerializeField] private GameObject gameplayUI;

    void Awake()
    {
        OpenDisplay();
    }

    public void OpenDisplay()
    {
        displayUI.SetActive(true);
        audioUI.SetActive(false);
        controlsUI.SetActive(false);
        gameplayUI.SetActive(false);
    }

    public void OpenAudio()
    {
        displayUI.SetActive(false);
        audioUI.SetActive(true);
        controlsUI.SetActive(false);
        gameplayUI.SetActive(false);
    }

    public void OpenControls()
    {
        displayUI.SetActive(false);
        audioUI.SetActive(false);
        controlsUI.SetActive(true);
        gameplayUI.SetActive(false);
    }

    public void OpenGameplay()
    {
        displayUI.SetActive(false);
        audioUI.SetActive(false);
        controlsUI.SetActive(false);
        gameplayUI.SetActive(true);
    }
}
