using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Detects player on platform for seemless motion as platform moves.
// Based on tutorial: https://youtu.be/ly9mK0TGJJo?si=oa7CsBvodWL9eHFO
// Last edited by Matthew Guo
public class PlatformDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Enter");
            other.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Exit");
            other.transform.SetParent(null);
        }
    }
}
