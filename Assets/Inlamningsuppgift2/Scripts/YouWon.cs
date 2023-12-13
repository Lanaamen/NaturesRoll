using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWon : MonoBehaviour
{
    private int numberOfStumps=6;
    public GameObject youWonScreen;

    //Metod för att återställa numberOfStumps och sätta youWonScreen som falsk, denna metod kallas
    // i skriptet bowlingReset, så att även dessa återställs när stumparna återställs
    public void Restart()
    {
        //Återställer numberOfStumps till 6
       numberOfStumps=6; 
       //Sätter youWonScreen som falsk
       youWonScreen.SetActive(false);
    }

  //Metod för när bowlingstumparna träffas och om man får en strike och då vinner, eller ej
  private void OnCollisionEnter(Collision collision)
    {
        //Om gamobjektet(bowlingstone) träffar gameobjekt med tagg bowlingstumps
        if (collision.collider.CompareTag("Bowlingstumps"))
        {
            //Om numberOfStumps är större än 0, alltså om man inte kolliderat med samtliga 6
            if (numberOfStumps> 0) 
            {
                //Subtrahera 1 från numberOfStumps samt inaktivera den kolliderade stumpen
                numberOfStumps=numberOfStumps-1;
                collision.collider.gameObject.SetActive(false);

                //om numberOfStumps är 0 eller likamed 0 så aktiveras youWonScreen
                if (numberOfStumps == 0) 
                
                {
                    youWonScreen.SetActive(true);
                }
            }
            
        }
    }

   
}
