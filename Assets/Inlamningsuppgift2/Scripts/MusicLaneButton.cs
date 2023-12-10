using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLaneButton : MonoBehaviour
{
    public AudioSource[] allAudioSources;

    void Start()
    {
        // Get all audio sources in the scene
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    public void OnButtonClick()
    {
        // Iterate through all audio sources and stop them
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.isPlaying && audioSource.gameObject != gameObject)
            {
                audioSource.Stop();
            }
        }
    }
}


