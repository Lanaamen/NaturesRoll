using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBowlingBall : MonoBehaviour
{
    // Define a variable to store the original position of the ball
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Set the original position when the game starts
        originalPosition = new Vector3 (-9.63f, 0.5f, -18.94f);
    }

    // Update is called once per frame
    void Update()
    {
        // Handle other game logic here

        // Check for input to trigger the restart (you can adapt this based on your input system)
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    // Function to restart the game
    void RestartGame()
    {
        // Reset the ball's position to the original position
        transform.position = originalPosition;

        // Add any other reset logic here (e.g., resetting score, resetting pins, etc.)
    }

}
