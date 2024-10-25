using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    //Player ball
    public GameObject ball;
    //Title level name
    public GameObject title;
    //Start button
    public GameObject startButton;
    //Level number
    public int levelNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Player not active
        ball.SetActive(false);
        //UI active
        startButton.SetActive(true);
        title.SetActive(true);

    }

    //Starting game method
    public void StartGame()
    {
        //Player is active
        ball.SetActive(true);
        //UI not active
        startButton.SetActive(false);
        title.SetActive(false);
    }

    //Complete Level
    public void LevelComplete()
    {
        //
        title.SetActive(true);
        title.GetComponent<Text>().text = "Level " + levelNumber + " complete!";
        //Player is not active
        ball.SetActive(false);
        //If level is less than 3
        if (levelNumber < 3)
        {
            //Load next level with delay
            StartCoroutine(LoadLevelWithDelay(levelNumber + 1));
        }
        else
        {
            //Laod level 1 with delay
            StartCoroutine(LoadLevelWithDelay(1)); // Back to level 1
        }

    }

    //Load Next Level Method
    public IEnumerator LoadLevelWithDelay(int levelNo)
    {
        yield return new WaitForSeconds(2.0f);
        //Opens new scene
        SceneManager.LoadScene("Level_" + levelNo); 
    }    
}
