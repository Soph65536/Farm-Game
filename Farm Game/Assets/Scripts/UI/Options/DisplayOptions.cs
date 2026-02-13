using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayOptions : MonoBehaviour
{
    [SerializeField] private Vector2[] resolutions;
    private int resolutionIndex;

    private FullScreenMode[] fullscreenModes = { FullScreenMode.ExclusiveFullScreen, FullScreenMode.FullScreenWindow, FullScreenMode.MaximizedWindow, FullScreenMode.Windowed };
    private int fullscreenIndex;

    [SerializeField] private TextMeshProUGUI resolutionText;
    [SerializeField] private TextMeshProUGUI fullscreenText;

    // Start is called before the first frame update
    void Awake()
    {
        if (resolutions.Length <= 0) { Debug.Log("ERROR: display settings doesn't include any resolutions"); }

        resolutionIndex = 0;
        fullscreenIndex = 0;

        resolutionText.text = resolutions[resolutionIndex].x.ToString() + " x " + resolutions[resolutionIndex].y.ToString();
        fullscreenText.text = fullscreenModes[fullscreenIndex].ToString();
    }

    public void ChangeResolution(bool positive)
    {
        //increase or decrease index based on if left or right button
        resolutionIndex += positive ? 1 : -1;
        if (resolutionIndex > resolutions.Length - 1) { resolutionIndex = 0; }
        else if (resolutionIndex < 0) { resolutionIndex = resolutions.Length - 1; }

        resolutionText.text = resolutions[resolutionIndex].x.ToString() + " x " + resolutions[resolutionIndex].y.ToString();
        UpdateResolution();
    }

    public void ChangeWindowed(bool positive)
    {
        //increase or decrease index based on if left or right button
        fullscreenIndex += positive ? 1 : -1;
        if (fullscreenIndex > fullscreenModes.Length - 1) { fullscreenIndex = 0; }
        else if (fullscreenIndex < 0) { fullscreenIndex = fullscreenModes.Length - 1; }

        fullscreenText.text = fullscreenModes[fullscreenIndex].ToString();
        UpdateResolution();
    }

    private void UpdateResolution()
    {
        Screen.SetResolution(
            (int)resolutions[resolutionIndex].x, 
            (int)resolutions[resolutionIndex].y, 
            fullscreenModes[fullscreenIndex]);
    }
}
