using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMainMenuMusic : MonoBehaviour
{
    public void Awake()
    {
        AudioManager.Instance.StopAudio(AudioManager.Instance.audioSource);
    }
}
