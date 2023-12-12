using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourCollectable : MonoBehaviour
{
    public GameObject player;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    player.GetComponent<ColourChange>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<ColourChange>().ChangeColor();
    }
}
