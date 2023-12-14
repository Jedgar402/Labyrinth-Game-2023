using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private int lives = 3;
    public Text LivesText;

    public int GetLives()
    {
        return lives;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            LoseLife();
            LivesText.text = "Lives: " + lives;
        }
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            lives = 0;
            // Call a method to handle game over, e.g., loading the game over scene
            GameOver();
        }
    }

    private void GameOver()
    {
        // Load the game over scene
        SceneManager.LoadScene("Game Over");
    }
}
