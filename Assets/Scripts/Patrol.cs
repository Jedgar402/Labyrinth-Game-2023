using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int currentpointIndex = 0;
    private float speed = 2f;

    //Called once a fram every frame
    private void Update()
    {
        //Transform of next waypoint
        Transform wp = points[currentpointIndex];
        //Check if the distance between object and waypoint is less than 0.01
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            //Change next waypoint
            currentpointIndex = (currentpointIndex + 1) % points.Length;
        }
        else
        {
            //Else move towards the waypoint
            transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
        }
    }
}
