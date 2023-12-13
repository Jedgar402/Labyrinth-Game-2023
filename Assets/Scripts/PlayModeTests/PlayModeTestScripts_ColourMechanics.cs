using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class PlayModeTestScripts_ColourMechanics
{
    private GameObject playerObject;
    private ColourChange playerColourChange;

    private GameObject ballObject;
    private Ball ballScript;

    private GameObject titleObject;
    private Text titleTextComponent;

    private GameObject goalObject;
    private GameController gameCont;

    [SetUp]
    public void SetUp()
    {
        // Arrange
        playerObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        playerColourChange = playerObject.AddComponent<ColourChange>();

        ballObject = new GameObject();
        ballObject.name = "Ball";
        ballScript = ballObject.AddComponent<Ball>();

        goalObject = new GameObject();
        goalObject.name = "Goal";
        gameCont = new GameObject().AddComponent<GameController>();
        ballScript.gameCont = gameCont;

        // Set title and ball explicitly
        gameCont.SetTitleAndBall(titleObject, ballObject);

        // Set title text explicitly
        gameCont.SetTitleText(titleTextComponent);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(playerObject);
        Object.Destroy(ballObject);
        Object.Destroy(goalObject);
        Object.Destroy(gameCont.gameObject);
    }

    [Test]
    public void ColourChangeOnCollect()
    {
        // Arrange
        GameObject collectableObject = new GameObject();
        ColourCollectable collectableScript = collectableObject.AddComponent<ColourCollectable>();
        collectableScript.player = playerObject;

        // Act
        playerColourChange.ChangeColor();
        collectableObject.AddComponent<BoxCollider>(); // To simulate a collider
        collectableScript.OnTriggerEnter(playerObject.GetComponent<BoxCollider>());

        // Assert
        Assert.IsNotNull(playerColourChange.nextMaterial);
        Assert.AreNotEqual(playerColourChange.gameObject.GetComponent<MeshRenderer>().material, playerColourChange.nextMaterial);
    }

    [Test]
    public void LevelCompleteOnColourMatch()
    {
        // Arrange
        GameObject ballObject = new GameObject("Ball");
        Ball ballScript = ballObject.AddComponent<Ball>();

        GameObject titleObject = new GameObject("Title");
        Text titleTextComponent = titleObject.AddComponent<Text>();
        GameController gameCont = new GameObject().AddComponent<GameController>();
        gameCont.SetTitleText(titleTextComponent);

        // Set up materials and shader
        Material ballMaterial = Resources.Load<Material>("RedGoal");
        ballObject.AddComponent<MeshRenderer>().material = ballMaterial;

        // Set the ball explicitly in the Ball script
        ballScript.gameCont = gameCont;

        GameObject goalObject = new GameObject("Goal");
        // MeshRenderer goalRenderer = goalObject.AddComponent<MeshRenderer>();
        goalObject.AddComponent<MeshRenderer>().material = ballMaterial;

        // Add a collider to the goalObject
        BoxCollider goalCollider = goalObject.AddComponent<BoxCollider>();

        bool levelCompleteCalled = false;

        // Act
        ballScript.OnTriggerEnter(goalObject.GetComponent<BoxCollider>());

        // Assert
        Assert.IsTrue(levelCompleteCalled);
    }

    [Test]
    public void LevelNotCompleteOnColourMismatch()
    {
        // Arrange
        GameObject ballObject = new GameObject("Ball");
        Ball ballScript = ballObject.AddComponent<Ball>();

        GameObject titleObject = new GameObject("Title");
        Text titleTextComponent = titleObject.AddComponent<Text>();
        GameController gameCont = new GameObject().AddComponent<GameController>();
        gameCont.SetTitleText(titleTextComponent);

        // Set up materials and shader
        Material ballMaterial = Resources.Load<Material>("RedGoal");
        ballObject.AddComponent<MeshRenderer>().material = ballMaterial;

        // Set the ball explicitly in the Ball script
        ballScript.gameCont = gameCont;

        GameObject goalObject = new GameObject("Goal");
        // MeshRenderer goalRenderer = goalObject.AddComponent<MeshRenderer>();
        goalObject.AddComponent<MeshRenderer>().material = Resources.Load<Material>("BlueGoal");

        // Add a collider to the goalObject
        BoxCollider goalCollider = goalObject.AddComponent<BoxCollider>();

        bool levelCompleteCalled = false;

        // Act
        ballScript.OnTriggerEnter(goalObject.GetComponent<BoxCollider>());

        // Assert
        Assert.IsFalse(levelCompleteCalled);
    }
}
