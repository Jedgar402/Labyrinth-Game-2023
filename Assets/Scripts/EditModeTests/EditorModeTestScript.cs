using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorModeTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void EnemyHelathDamage()
    {
        // Use the Assert class to test conditions
        int finalHealth = Enemy.DamageEnemy(05);

        //Assert
        Assert.AreEqual(expected: 0, actual: finalHealth);
    }

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

        //ASsert
        int expectedLives = 3;
        Assert.AreEqual(expectedLives, livesScript.GetLives());
    }

    [Test]
    public void TestLivesDamage()
    {
        //Arrange
        GameObject testObject = new GameObject();
        Lives livesScript = testObject.AddComponent<Lives>();

        //Act
        int expectedLivesAfterDamage = 2;
        livesScript.LoseLife();

        //ASsert
        Assert.AreEqual(expectedLivesAfterDamage, livesScript.GetLives());
    }

    [Test]
    public void ChangeColor_CyclesThroughMaterials()
    {
        // Arrange
        GameObject testObject = new GameObject();
        ColourChange colourChange = testObject.AddComponent<ColourChange>();
        MeshRenderer meshRenderer = testObject.AddComponent<MeshRenderer>();

        // Act
        colourChange.ChangeColor();
        Material initialMaterial = colourChange.nextMaterial;

        // Change color and check if it's different
        colourChange.ChangeColor();
        Material changedMaterial = colourChange.nextMaterial;

        // Assert
        Assert.IsNotNull(meshRenderer, "MeshRenderer component not found on the object.");
        Assert.AreNotEqual(initialMaterial, changedMaterial);
    }

    [Test]
    public void GetMaterials_LoadsMaterialsArray()
    {
        // Arrange
        GameObject testObject = new GameObject();
        ColourChange colourChange = testObject.AddComponent<ColourChange>();

        // Act
        colourChange.GetMaterials();

        // Assert
        Assert.IsNotNull(colourChange.materials);
        Assert.IsTrue(colourChange.materials.Length > 0);
    }
}
