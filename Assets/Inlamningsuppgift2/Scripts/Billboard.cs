using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

void Update()
    {
        // Roterar objektet på x-axeln så den riktar sig mot kameran
        if (mainCamera != null)
        {
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;

            directionToCamera.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

            transform.rotation = Quaternion.Euler(targetRotation.eulerAngles.x, 0, 0);
        }
    }
}
