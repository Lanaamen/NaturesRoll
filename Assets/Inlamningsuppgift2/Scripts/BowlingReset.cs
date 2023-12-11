using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingReset : MonoBehaviour
{
    public GameObject bowlingStone; // Assign this in the inspector
    public Transform[] individualKeggles; // Assign each keggle in the inspector

    private Vector3 initialBowlingStonePosition;
    private Quaternion initialBowlingStoneRotation;
    private Vector3[] initialKegglePositions;
    private Quaternion[] initialKeggleRotations;

    private void Start()
    {
        Button resetButton = GetComponent<Button>();

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetGame);
        }
        else
        {
            Debug.LogError("No Button component found on the GameObject. Attach this script to a UI button.");
        }

        // Store the initial position and rotation of the bowling stone
        if (bowlingStone != null)
        {
            initialBowlingStonePosition = bowlingStone.transform.position;
            initialBowlingStoneRotation = bowlingStone.transform.rotation;
        }
        else
        {
            Debug.LogError("Bowling stone not set. Assign it in the inspector.");
        }

        // Store the initial position and rotation of each individual keggle
        initialKegglePositions = new Vector3[individualKeggles.Length];
        initialKeggleRotations = new Quaternion[individualKeggles.Length];

        for (int i = 0; i < individualKeggles.Length; i++)
        {
            if (individualKeggles[i] != null)
            {
                initialKegglePositions[i] = individualKeggles[i].position;
                initialKeggleRotations[i] = individualKeggles[i].rotation;
            }
            else
            {
                Debug.LogError($"Individual keggle {i + 1} not set. Assign it in the inspector.");
            }
        }
    }

    private void ResetGame()
    {
        // Reset the bowling stone to its initial position
        if (bowlingStone != null)
        {
            bowlingStone.transform.position = initialBowlingStonePosition;
            bowlingStone.transform.rotation = initialBowlingStoneRotation;
        }
        else
        {
            Debug.LogError("Bowling stone not set. Assign it in the inspector.");
        }

        // Reset each individual keggle to its initial position
        for (int i = 0; i < individualKeggles.Length; i++)
        {
            if (individualKeggles[i] != null)
            {
                individualKeggles[i].position = initialKegglePositions[i];
                individualKeggles[i].rotation = initialKeggleRotations[i];
            }
            else
            {
                Debug.LogError($"Individual keggle {i + 1} not set. Assign it in the inspector.");
            }
        }
    }
}


