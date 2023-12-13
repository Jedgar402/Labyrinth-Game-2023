using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    private Material[] materials; // Array of colors to cycle through

    public float colorChangeInterval = 1f; // Time interval between color changes

    private int currentColorIndex = 0;
    public Material nextMaterial;

    private void Awake()
    {
        GetMaterials();
    }

    private void GetMaterials()
    {
        string[] materialNames = { "BlueGoal", "GreenGoal", "RedGoal" };
        List<Material> loadedMaterials = new List<Material>();

        foreach (string materialName in materialNames)
        {
            Material material = Resources.Load<Material>("Materials/" + materialName);

            if (material != null)
            {
                loadedMaterials.Add(material);
            }
            else
            {
                Debug.LogError("Failed to load material: " + materialName);
            }
        }

        materials = loadedMaterials.ToArray();
    }

    void Start()
    {

        if (materials == null || materials.Length == 0)
        {
            Debug.LogError("No materials found in the 'Materials' folder within the 'Resources' folder.");
        }

        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            nextMaterial = renderer.material;
        }
        else
        {
            Debug.LogError("Renderer component not found on the object.");
        }
    }

    public void ChangeColor()
    {
        GetMaterials();

        Debug.Log("Current Color Index: " + currentColorIndex);

        if (materials != null && materials.Length > 0)
        {
            currentColorIndex = (currentColorIndex + 1) % materials.Length;

            Renderer renderer = gameObject.GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                nextMaterial = materials[currentColorIndex];
                renderer.material = nextMaterial;
            }
            else
            {
                Debug.LogError("Renderer component not found on the object.");
            }
        }
        else
        {
            Debug.LogError("Materials array is null or empty.");
            Debug.Log("Materials array length: " + (materials != null ? materials.Length : 0));
        }
    }

}

