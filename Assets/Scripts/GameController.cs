using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject title;
    public GameObject startButton;

    public int levelNumber = 1;

    private Text titleText;

    void Start()
    {
        ball.SetActive(false);

        //UI
        startButton.SetActive(true);
        title.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        ball.SetActive(true);
        startButton.SetActive(false);
        title.SetActive(false);
    }


    public void LevelComplete()
    {
        title.SetActive(true);
        title.GetComponent<Text>().text = "Level " + levelNumber + " complete!";
        ball.SetActive(false);

        if (levelNumber < 3)
        {
            StartCoroutine(LoadLevelWithDelay(levelNumber + 1));
        }
        else
        {
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
    
    
    
    //public GameObject ball;
    //public GameObject title;
    //public GameObject startButton;

    //public int levelNumber = 1;

    //private Text titleText;

    //void Start()
    //{
    //    ball.SetActive(false);
    //    startButton.SetActive(true);
    //    title.SetActive(true);

    //    //// Assign Ball script to the ball GameObject
    //    //if (ball == null)
    //    //{
    //    //    ball = GameObject.Find("Ball");

    //    //    if (ball != null)
    //    //    {
    //    //        Ball ballScript = ball.GetComponent<Ball>();

    //    //        if (ballScript != null)
    //    //        {
    //    //            ballScript.gameCont = this;
    //    //        }
    //    //        else
    //    //        {
    //    //            Debug.LogError("Ball script not found on the player GameObject.");
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        Debug.LogError("Ball GameObject not found.");
    //    //    }
    //    //}

    //    //if (startButton == null)
    //    //{
    //    //    startButton = GameObject.FindGameObjectWithTag("Start Button");
    //    //    // UI
    //    //    startButton.SetActive(true);
    //    //}
    //    //else
    //    //{
    //    //    // UI
    //    //    startButton.SetActive(true);
    //    //}

    //    //if (title == null)
    //    //{
    //    //    title = GameObject.FindGameObjectWithTag("Title");
    //    //    title.SetActive(true);
    //    //}
    //    //else
    //    //{
    //    //    title.SetActive(true);
    //    //}
    //}

    ////Start Button Method
    //public void StartGame()
    //{
    //    ball.SetActive(true);
    //    startButton.SetActive(false);
    //    title.SetActive(false);
    //}

    ////private void SetUpGame()
    ////{
    ////    if (ball != null && startButton != null && title != null) 
    ////    { 
    ////        ball.SetActive(false);
    ////        startButton.SetActive(true);
    ////        title.SetActive(true);
    ////    }
    ////    else
    ////    {
    ////        ball = GameObject.FindGameObjectWithTag("Player");
    ////        startButton = GameObject.FindGameObjectWithTag("Start Button");
    ////        title = GameObject.FindGameObjectWithTag("Title");
    ////    }
    ////}

    ////public void SetBall(GameObject ballObject)
    ////{
    ////    ball = ballObject;
    ////}

    ////public void SetTitleAndBall(GameObject titleObject, GameObject ballObject)
    ////{
    ////    title = GameObject.Find("Title");
    ////    title = titleObject;
    ////    ball = GameObject.Find("Ball");
    ////    ball = ballObject;   
    ////}

    ////public void SetTitleText(Text titleTextComponent)
    ////{
    ////    titleText = titleTextComponent;
    ////}

    
    ////Level Complete Method
    //public void LevelComplete()
    //{
    //    //SetTitleAndBall(title, ball);

    //    if (title != null)
    //    {
    //        title = GameObject.Find("Title");

    //        if (titleText != null)
    //        {
    //            titleText.text = "Level " + levelNumber + " complete!";
    //        }
    //        else
    //        {
    //            Debug.LogError("Text component not found on the title GameObject.");
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Title GameObject not found.");
    //    }

    //    if (ball != null)
    //    {
    //        ball.SetActive(false);

    //        if (levelNumber < 3)
    //        {
    //            StartCoroutine(LoadLevelWithDelay(levelNumber + 1));
    //        }
    //        else
    //        {
    //            //Back to level 1
    //            StartCoroutine(LoadLevelWithDelay(1)); 
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Ball GameObject not found.");
    //    }
    //}
}
