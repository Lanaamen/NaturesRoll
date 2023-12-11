using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapBack : MonoBehaviour
{
    //Skapar en variabel som refererar till XRGrabInteractable komponenten
    private XRGrabInteractable grabInteractable;
    //Skapar en variabel för objektets initialposition
    private Vector3 initialPosition;
    //Skapar en variabel som refererar till Audiosource komponenten
    private AudioSource audioSource;
    //En bool som håller koll på när ljudet spelas
    private bool isPlaying = false;

    //[Header("Events")]
    //public UnityEvent onGrab;
    //public UnityEvent onRelease;

    [Header("Audio")]
    public AudioClip grabSound; //Gör de möjligt att lägga till audioklipp i inspektorfönstret

    void Start()
    {
        //Hämtar XRGrabInteractable-komponenten
        grabInteractable = GetComponent<XRGrabInteractable>();

        //Här sparas den initiala positionen för objektet
        initialPosition = transform.position;

        //Här läggs en audiosourcekomponent till objektet
        audioSource = gameObject.AddComponent<AudioSource>();

        //konfiguration för audiosourcekomponenten
        //Gör så att ljudet inte startar automatiskt
        audioSource.playOnAwake = false;
        //Gör så att ljudet spelas i en loop
        audioSource.loop = true;

        //När objektet greppas/släpps läggs en lyssnare till (addlistener)
        //som körs när onselect(enter/exit) händelsen inträffar (ongrab/onrelease)

        //Prenumeration på onselectenter händelsen för att detektera när objektet grips
        grabInteractable.onSelectEntered.AddListener(OnGrab);

        //Prenumeration på onselectenter händelsen för att detektera när objektet släpps
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    //metod för när objektet greppas
    private void OnGrab(XRBaseInteractor interactor)
    {
        // Objektet greppas
        onGrab.Invoke();

        // När objektet föst greppas spelas ljudet
        if (!isPlaying && grabSound != null && audioSource != null)
        {
            audioSource.clip = grabSound;
            audioSource.Play();
            isPlaying = true;
        }
    }

    //metod för när objektet släpps
    private void OnRelease(XRBaseInteractor interactor)
    {
        //När objektet släpps, snappar den tillbaka till den initiala positionen
        transform.position = initialPosition;

        //Triggar onRelease eventet
        onRelease.Invoke();

        //Återställer boolen så att ongrab metoden kan avgöra om ljudet redan spelas nästa gång objektet greppas
        isPlaying = false;
    }
}
