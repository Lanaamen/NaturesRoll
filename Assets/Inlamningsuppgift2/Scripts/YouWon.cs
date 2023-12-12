using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWon : MonoBehaviour
{
    private int numberOfStumps=6;
    public GameObject youWonScreen;

    // Start is called before the first frame update
    public void Restart()
    {
       numberOfStumps=6; 
       youWonScreen.SetActive(false);
    }

  private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bowlingstumps"))
        {
            if (numberOfStumps> 0) 
            {
                numberOfStumps=numberOfStumps-1;
                collision.collider.gameObject.SetActive(false);
                if (numberOfStumps == 0) 
                
                {
                    youWonScreen.SetActive(true);
                }
            }
            
        }
    }

   
}
