using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider seSlider;
    [SerializeField] private Slider ambientSlider;

    private float VolumeCalculation(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    public void SetMusic(float value)
    {
        audioMixer.SetFloat("MusicVolume", VolumeCalculation(value));
    }
    public void SetSE(float value)
    {
        audioMixer.SetFloat("SEVolume", VolumeCalculation(value));
    }
    public void SetAmbient(float value)
    {
        audioMixer.SetFloat("AmbientVolume", VolumeCalculation(value));
    }
}
