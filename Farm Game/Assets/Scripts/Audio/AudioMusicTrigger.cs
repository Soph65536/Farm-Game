using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioMusicTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private string musicToPlay;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayMusic();
    }

    private void OnTriggerExit(Collider other)
    {
        AudioManager.Instance.StopAudio(audioSource);
    }

    public void PlayMusic()
    {
        AudioManager.Instance.PlayAudio(true, audioSource, musicToPlay);
    }
}
