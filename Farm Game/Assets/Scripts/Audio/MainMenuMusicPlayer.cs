using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicPlayer : MonoBehaviour
{
    [SerializeField] private string mainMenuMusic;

    private void Start()
    {
        AudioManager.Instance.PlayAudio(false, AudioManager.Instance.audioSource, mainMenuMusic);
    }
}
