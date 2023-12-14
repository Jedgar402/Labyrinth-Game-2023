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
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col != null)
        {
            if (col.gameObject.name == "Goal")
            {
                Material goalMaterial = col.gameObject.GetComponent<MeshRenderer>().material;
                Material thisMaterial = this.gameObject.GetComponent<MeshRenderer>().material;

                Debug.Log("thisMaterial.color: " + thisMaterial.color);
                Debug.Log("goalMaterial.color: " + goalMaterial.color);

                if (thisMaterial.color == goalMaterial.color)
                {
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
