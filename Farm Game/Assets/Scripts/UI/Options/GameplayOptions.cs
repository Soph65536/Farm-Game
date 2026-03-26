using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayOptions : MonoBehaviour
{
    //x look speed is this*2, y look speed is this/100
    const float minLookSpeed = 40;
    const float maxLookSpeed = 300;

    [SerializeField] private Slider cameraSensitivitySlider;

    public static GameplayOptions Instance { get; private set; }
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

        cameraSensitivitySlider.minValue = minLookSpeed;
        cameraSensitivitySlider.maxValue = maxLookSpeed;
        cameraSensitivitySlider.value = maxLookSpeed/2;
    }

    public void UpdateLookSpeed()
    {
        if (CameraController.Instance != null) { CameraController.Instance.SetSensitivity(cameraSensitivitySlider.value * 2, cameraSensitivitySlider.value / 100); }
    }
}
