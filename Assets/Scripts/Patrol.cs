using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int currentpointIndex = 0;
    private float speed = 2f;

    private void Update()
    {
        Transform wp = points[currentpointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            currentpointIndex = (currentpointIndex + 1) % points.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
        }
    }
}
