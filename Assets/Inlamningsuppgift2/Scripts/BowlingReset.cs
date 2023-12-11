using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingReset : MonoBehaviour
{
    //Variabel för bowlingStone
    public GameObject bowlingStone;
    //Variabel som tillåter oss att dra in flera gameobjekt i inspektorfönstret och registrera varderas transform komponent
    //detta gör vi för varje inviduell bowlingstump
    public Transform[] individualStumps;
    //Nedan bevaras resterade delar av transformkomponenten
    private Vector3 initialBowlingStonePosition;
    private Quaternion initialBowlingStoneRotation;
    private Vector3[] initialStumpPositions;
    private Quaternion[] initialStumpRotations;

    private void Start()
    {
        Button resetButton = GetComponent<Button>();

        /*if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetGame);
        }
        else
        {
            Debug.LogError("No Button component found on the GameObject. Attach this script to a UI button.");
        }*/

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
        initialStumpPositions = new Vector3[individualStumps.Length];
        initialStumpRotations = new Quaternion[individualStumps.Length];

        for (int i = 0; i < individualStumps.Length; i++)
        {
            if (individualStumps[i] != null)
            {
                initialStumpPositions[i] = individualStumps[i].position;
                initialStumpRotations[i] = individualStumps[i].rotation;
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
        for (int i = 0; i < individualStumps.Length; i++)
        {
            if (individualStumps[i] != null)
            {
                individualStumps[i].position = initialStumpPositions[i];
                individualStumps[i].rotation = initialStumpRotations[i];
            }
            else
            {
                Debug.LogError($"Individual keggle {i + 1} not set. Assign it in the inspector.");
            }
        }
    }
}


