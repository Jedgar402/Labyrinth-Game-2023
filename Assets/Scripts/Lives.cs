using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private int lives = 3;
    public Text LivesText;

    private void Update()
    {
        if(lives == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            lives--;
            LivesText.text = "Lives: " + lives;
        }
    }
}

    

