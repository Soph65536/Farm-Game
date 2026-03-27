using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioLibrary
{
    public string clipName;
    public AudioClip[] audioClips;
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioLibrary[] audioClips;

    public static AudioManager Instance { get; private set; }

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

        audioSource = GetComponent<AudioSource>();
    }


    private AudioClip[] FindAudioFromClipName(string clipName)
    {
        foreach (AudioLibrary audioLibrary in audioClips)
        {
            if (audioLibrary.clipName == clipName)
            {
                return audioLibrary.audioClips;
            }
        }
        return null;
    }

    private void PlayAudioClip(bool looping, AudioSource audioSource, AudioClip clipToPlay)
    {
        if (looping)
        {
            StopAudio(audioSource);
            audioSource.loop = true;
            audioSource.clip = clipToPlay;

            audioSource.Play();
        }
        else
        {
            audioSource.PlayOneShot(clipToPlay);
        }
    }


    public void PlayAudio(bool looping, AudioSource audioSource, string clipName) //plays random audio associated with the string name param
    {
        //this will be the selection of clips associated with the clipname,
        //of which a random clip will be selected to play
        AudioClip[] clipsToPlay = FindAudioFromClipName(clipName);

        if (clipsToPlay != null)
        {
            //prevents the same looping audio from being replayed
            if (looping)
            {
                foreach (AudioClip clip in clipsToPlay)
                {
                    if (clip == audioSource.clip) { return; }
                }
            }

            AudioClip clipToPlay = clipsToPlay[UnityEngine.Random.Range(0, clipsToPlay.Length)]; //choose a random clip from the selection of audio clips

            PlayAudioClip(looping, audioSource, clipToPlay);
        }
    }

    public void PlayAudio(bool looping, AudioSource audioSource, string clipName, int ClipIndex) //version with specific clip index to reference
    {
        //this will be the selection of clips associated with the clipname,
        //of which a random clip will be selected to play
        AudioClip[] clipsToPlay = FindAudioFromClipName(clipName);

        if (clipsToPlay != null)
        {
            PlayAudioClip(looping, audioSource, clipsToPlay[ClipIndex]);
        }
    }

    public void StopAudio(AudioSource audioSource)
    {
        audioSource.Stop();
    }
}
