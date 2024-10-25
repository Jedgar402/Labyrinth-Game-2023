using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private int lives = 3;
    public Text LivesText;

    //Get lives method
    public int GetLives()
    {
        return lives;
    }

    //On trigger enter
    void OnTriggerEnter(Collider collision)
    {
        //Check it the tag is an enemy
        if (collision.gameObject.tag == "Enemy")
        {
            //Loose a life method
            LoseLife();
            //Update UI
            LivesText.text = "Lives: " + lives;
        }
    }

    //Loose a life method
    public void LoseLife()
    {
        //Take 1 off the lives counter
        lives--;

        //If lives are 0 or less
        if (lives <= 0)
        {
            //Set to 0
            lives = 0;
            // Call a method to handle game over, e.g., loading the game over scene
            GameOver();
        }
    }

    //Game over method
    private void GameOver()
    {
        // Load the game over scene
        SceneManager.LoadScene("Game Over");
    }
}
