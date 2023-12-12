using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingReset : MonoBehaviour
{
    public GameObject wonScreen;
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
       */

        //Sparar bowlingklotets initiala position och rotation
        if (bowlingStone != null)
        {
            initialBowlingStonePosition = bowlingStone.transform.position;
            initialBowlingStoneRotation = bowlingStone.transform.rotation;
        }

        //Sparar varje inviduella stumps initiala position och rotiation
        initialStumpPositions = new Vector3[individualStumps.Length];
        initialStumpRotations = new Quaternion[individualStumps.Length];

        for (int i = 0; i < individualStumps.Length; i++)
        {
            if (individualStumps[i] != null)
            {
                initialStumpPositions[i] = individualStumps[i].position;
                initialStumpRotations[i] = individualStumps[i].rotation;
            }
        }
    }

    public void ResetGame()
    {
        //wonScreen.setActive(false);

        //Sätter tillbaka bowlingklotet till sin initiala position
        if (bowlingStone != null)
        {
            bowlingStone.transform.position = initialBowlingStonePosition;
            bowlingStone.transform.rotation = initialBowlingStoneRotation;
        }

        //Sätter tillbaka varje inviduella stump till respektive initiala position
        for (int i = 0; i < individualStumps.Length; i++)
        {
            if (individualStumps[i] != null)
            {
                individualStumps[i].position = initialStumpPositions[i];
                individualStumps[i].rotation = initialStumpRotations[i];
            }

        }
    }
}


