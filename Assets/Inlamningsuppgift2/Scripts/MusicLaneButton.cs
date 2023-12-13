using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLaneButton : MonoBehaviour
{
    public AudioSource[] allAudioSources;

    void Start()
    {
        //Här deklareras en array tillgängnad till AudioSorces, som vi döper Till allaudiosources,
        //Detta för att de är här vi kommer att spara referenser till alla audiosource komponenter i scenen.
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    //Här skapar vi en funktion för när knappen trycks.
    public void OnButtonClick()
    {
        // Denna foreach sats går igenom alla audiosources och stoppar audion om den spelas.
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.isPlaying && audioSource.gameObject != gameObject)
            {
                audioSource.Stop();
            }
        }
    }
}


