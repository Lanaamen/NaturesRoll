using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//line of code that gives you access to manage scenes
using UnityEngine.SceneManagement;

public class BowlingGameScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private GameObject gameWonScreen;


    //Function with code that restarts the game by restarting the scene
    public void restartGame()
    {
        //'SceneManager.LoadScene' looks for the scene
        //'SceneManager.GetActiveScene' calls the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Function for when the player loses the game
    public void gameOver()
    {
        gameOverScreen.SetActive(true);

    }

    //Function for when the player wins the game
    public void gameWon()
    {
        gameWonScreen.SetActive(true);
   
    }


}
