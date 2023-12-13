using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingReset : MonoBehaviour
{
    //Variabel för YouWonScreen
    public GameObject youWonScreen;
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

        //Button resetButton = GetComponent<Button>();


        //Sparar bowlingklotets initiala position och rotation
        initialBowlingStonePosition = bowlingStone.transform.position;
        initialBowlingStoneRotation = bowlingStone.transform.rotation;


        //Sparar varje inviduella stumps initiala position och rotiation
        initialStumpPositions = new Vector3[individualStumps.Length];
        initialStumpRotations = new Quaternion[individualStumps.Length];

        for (int i = 0; i < individualStumps.Length; i++)
        {
            initialStumpPositions[i] = individualStumps[i].position;
            initialStumpRotations[i] = individualStumps[i].rotation;
        }
    }

    public void ResetBowlingStone()
    {

        //Sätter tillbaka bowlingklotet till sin initiala position
        bowlingStone.transform.position = initialBowlingStonePosition;
        bowlingStone.transform.rotation = initialBowlingStoneRotation;


    }
    public void ResetBowlingStumps()
    {
        //Hämtar YouWonscripts-komponenten från gameobjektet youwonscreen och kallar på restartmetoden
        youWonScreen.GetComponent<YouWon>().Restart();

        //Sätter tillbaka varje inviduella stump till respektive initiala position
        for (int i = 0; i < individualStumps.Length; i++)
        {
            //Hämtar Rigidbodykomponenten för respektive inviduella stumpar
            Rigidbody stumpRigidbody = individualStumps[i].GetComponent<Rigidbody>();

            // Sparar aktuell gravitation
            Vector3 gravity = Physics.gravity;

            // Stänger av gravitation under återställningen
            Physics.gravity = Vector3.zero;

            //Fryser rigidbodys fysikinteraktioner innan återställning utav stumparna
            stumpRigidbody.constraints = RigidbodyConstraints.FreezeAll;

            //Återställer position och rotation för varje inviduella stump
            individualStumps[i].position = initialStumpPositions[i];
            individualStumps[i].rotation = initialStumpRotations[i];

            //Återställer fysikinteraktionerna för varje inviduella stump
            stumpRigidbody.constraints = RigidbodyConstraints.None;

            //Återaktiverar varje inviduella stump
            individualStumps[i].gameObject.SetActive(true);

            // Återställer gravitation till det ursprungliga värdet
            Physics.gravity = gravity;
        }
    }

}