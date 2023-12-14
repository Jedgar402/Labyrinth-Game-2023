using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class PlayModeTest_UI
{
    [UnityTest]
    public IEnumerator TestRestartLevelButton()
    {
        // Load test scene
        SceneManager.LoadScene("Game Over");

        yield return null;
        // Find button in the scene
        Button restartButton = GameObject.Find("RestartButton").GetComponent<Button>();

        //Presses button
        restartButton.onClick.Invoke();

        yield return new WaitForSeconds(1f);

        // Tests to see if the name of the scenes is the same
        Assert.AreEqual("Level_1", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator LoseAllLives()
    {
        SceneManager.LoadScene("Level_1");

        yield return null;

        Lives gameController = GameObject.FindObjectOfType<Lives>();

        gameController.LoseLife();
        gameController.LoseLife();
        gameController.LoseLife();

        yield return new WaitForSeconds(1f);

        Assert.AreEqual("Game Over", SceneManager.GetActiveScene().name);

    }

    
}
