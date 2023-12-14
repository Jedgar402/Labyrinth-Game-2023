using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourCollectable : MonoBehaviour
{
    public GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        player.GetComponent<ColourChange>().ChangeColor();

        Destroy(gameObject);
    }
}
