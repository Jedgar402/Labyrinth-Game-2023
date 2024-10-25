using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameController gameCont;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        if (gameCont == null)
        {
            // Find the GameController using a tag (adjust the tag accordingly)
            gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            //Debug.LogError("GameController not found. Make sure it exists in the scene and has the GameController component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update the material for the colour change mechanic
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    public void OnTriggerEnter(Collider col)
    {
        //if the collider is not null / if it exists
        if (col != null)
        {
            //Check if the object is goal
            if (col.gameObject.name == "Goal")
            {
                //Get the goal and player materials
                Material goalMaterial = col.gameObject.GetComponent<MeshRenderer>().material;
                Material thisMaterial = this.gameObject.GetComponent<MeshRenderer>().material;

                Debug.Log("thisMaterial.color: " + thisMaterial.color);
                Debug.Log("goalMaterial.color: " + goalMaterial.color);

                //Check if they are the same materials
                if (thisMaterial.color == goalMaterial.color)
                {
                    //Complete level if they are the same
                    gameCont.LevelComplete();
                }
            }
        }
        else
        {
            Debug.LogError("Collider is null or not present on the object.");
        }
    }
}
