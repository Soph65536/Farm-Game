using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TriggerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private string musicToPlay;
    [SerializeField] private bool looping;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayAudio();
    }

    private void OnTriggerExit(Collider other)
    {
        AudioManager.Instance.StopAudio(audioSource);
    }

    public void PlayAudio()
    {
        AudioManager.Instance.PlayAudio(looping, audioSource, musicToPlay);
    }
}
