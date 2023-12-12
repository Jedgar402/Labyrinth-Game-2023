using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public Color[] colors; // Array of colors to cycle through
    public float colorChangeInterval = 1f; // Time interval between color changes

    private int currentColorIndex = 0;
    private Rigidbody rb;
    private Material material;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Add any additional logic based on the color
        HandleColorEffects();
    }

    public void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        material.color = colors[currentColorIndex];
    }

    void HandleColorEffects()
    {
        Color currentColor = material.color;

        // Example: Define different behaviors for each color
        if (currentColor == Color.red)
        {
            // Do something specific for red color
            Debug.Log("Red Color Effect");
        }
        else if (currentColor == Color.blue)
        {
            // Do something specific for blue color
            Debug.Log("Blue Color Effect");
        }
    }
}

