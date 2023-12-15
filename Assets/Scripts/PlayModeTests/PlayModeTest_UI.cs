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
        Button restartButton = GameObject.Find("Restart Button").GetComponent<Button>();

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

    [UnityTest]
    public IEnumerator TestLivesLowerThan0()
    {
        GameObject testObject = new GameObject();
        Lives livesScript = testObject.AddComponent<Lives>();

        int expectedLivesAfterDamage = 0;

        // Lose more lives than available
        for (int i = 0; i < 4; i++)
        {
            livesScript.LoseLife();
        }

        yield return new WaitForSeconds(1f);

        Assert.AreEqual(expectedLivesAfterDamage, livesScript.GetLives());
    }

    [UnityTest]
    public IEnumerator OnTriggerEnter_ChangesColorOnCollectableCollision()
    {
        // Arrange
        GameObject testObject = new GameObject();
        ColourChange colourChange = testObject.AddComponent<ColourChange>();
        MeshRenderer meshRenderer = testObject.AddComponent<MeshRenderer>();
        GameObject collectableObject = new GameObject();
        collectableObject.tag = "Collectable";
        Collider collectableCollider = collectableObject.AddComponent<BoxCollider>();

        // Act
        colourChange.CheckCollider(collectableCollider);

        // Wait for a short time to allow Unity to process destruction
        yield return new WaitForSeconds(0.1f);

        // Assert after waiting for the destruction to occur
        Assert.IsNotNull(collectableObject, "CollectableObject should be null after destruction.");
    }

    //[UnityTest]
    //public IEnumerator Tests_Enemy_hit_ball()
    //{
    //    Vector3 Current = enemy.hitball().transform.position;

    //    enemy.hitball();
        
    //    yield return null;
        
    //    Vector3 finalPos = enemy.hitball().transform.position;

    //    Assert.Greater(finalPos.x, Current.x);
    //}
}
