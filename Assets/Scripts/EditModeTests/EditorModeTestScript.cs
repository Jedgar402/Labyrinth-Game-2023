using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorModeTestScript
{
    [Test]
    public void TestQuitLevelButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    [Test]
    public void TestLives()
    {
        // Create an empty game object and add the Lives script to it
        GameObject testObject = new GameObject();
        Lives livesScript = testObject.AddComponent<Lives>();

        int expectedLives = 3;
        Assert.AreEqual(expectedLives, livesScript.GetLives());
    }

    [Test]
    public void TestLivesDamage()
    {
        GameObject testObject = new GameObject();
        Lives livesScript = testObject.AddComponent<Lives>();

        int expectedLivesAfterDamage = 2;
        livesScript.LoseLife();

        Assert.AreEqual(expectedLivesAfterDamage, livesScript.GetLives());
    }
}
