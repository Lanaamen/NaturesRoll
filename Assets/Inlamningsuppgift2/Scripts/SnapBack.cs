using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapBack : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Vector3 initialPosition;

    void Start()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Record the initial position of the GameObject
        initialPosition = transform.position;

        // Subscribe to the onFirstHoverEntered event to detect when the object is grabbed
        grabInteractable.onSelectEntered.AddListener(OnGrab);

        // Subscribe to the onLastHoverExited event to detect when the object is released
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Object is grabbed, you can add any additional logic here if needed
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // Object is released, snap back to the initial position
        transform.position = initialPosition;
    }
}
