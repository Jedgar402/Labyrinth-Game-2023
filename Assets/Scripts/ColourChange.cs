using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    // Array of colors to cycle through
    public Material[] materials;

    // Time interval between color changes
    public float colorChangeInterval = 1f;
    //Index to tell what colour is used
    public int currentColorIndex = 0;
    //Next materials
    public Material nextMaterial;

    //Before Start is called
    private void Awake()
    {
        //Get materials from resources
        GetMaterials();
    }

    public void GetMaterials()
    {
        //Array of names for materials
        string[] materialNames = { "BlueGoal", "GreenGoal", "RedGoal" };
        //List of loaded materials
        List<Material> loadedMaterials = new List<Material>();
        //For each loop checking and adding names of materials to list
        foreach (string materialName in materialNames)
        {
            //Materials load from resources with name of material
            Material material = Resources.Load<Material>("Materials/" + materialName);
            //If material is not null / if it exists
            if (material != null)
            {
                //Add material to list
                loadedMaterials.Add(material);
            }
            else
            {
                //Else throw error
                Debug.LogError("Failed to load material: " + materialName);
            }
        }
        //Add loadedMateriasl to materials array
        materials = loadedMaterials.ToArray();
    }

    void Start()
    {
        //Check array is null or 0
        if (materials == null || materials.Length == 0)
        {
            //
            Debug.LogError("No materials found in the 'Materials' folder within the 'Resources' folder.");
        }

        //Getting the mesh renderer of the object
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        //Check if the render is not null / if it exits
        if (renderer != null)
        {
            //Next material assigned through renderer
            nextMaterial = renderer.material;
        }
        else
        {
            //Else throw error
            Debug.LogError("Renderer component not found on the object.");
        }
    }

    //Change colour method
    public void ChangeColor()
    {
        //Get the materials
        GetMaterials();
        //Output current indec
        Debug.Log("Current Color Index: " + currentColorIndex);

        //Check array is null or 0
        if (materials != null && materials.Length > 0)
        {
            //Go to next indec
            currentColorIndex = (currentColorIndex + 1) % materials.Length;
            //Get renderer
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
            //If renderer is not null / it exists
            if (renderer != null)
            {
                //next material is the next index
                nextMaterial = materials[currentColorIndex];
                renderer.material = nextMaterial;
            }
            else
            {
                //Throw error 
                Debug.LogError("Renderer component not found on the object.");
            }
        }
        else
        {
            Debug.LogError("Materials array is null or empty.");
            Debug.Log("Materials array length: " + (materials != null ? materials.Length : 0));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Check collider
        CheckCollider(other);
    }

    public void CheckCollider(Collider other)
    {
        //If the collider is not null / if it exists and the tag is Collectable
        if (other != null && other.gameObject.CompareTag("Collectable"))
        {
            //Change colour
            ChangeColor();

            // Destroy the GameObject, including the Collider component
            Destroy(other.gameObject);

            // Set the reference to null explicitly
            other = null;
        }
    }

}
