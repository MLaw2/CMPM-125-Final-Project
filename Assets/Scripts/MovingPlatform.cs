using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Platform moves towards waypoints in a loop
// Based on tutorial: https://youtu.be/VcxsK5khTms?si=hWder4o561vNIruF
// Last edited by Matthew Guo
public class MovingPlatform : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;

    // recieves data first
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
    }
    // use data from Update()
    private void FixedUpdate()
    {
        if(transform.position == waypoints[target].position)
        {
            if(target == waypoints.Count - 1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }
    }
}
