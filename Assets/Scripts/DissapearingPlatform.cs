using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Platforms that toggle on and off
// Based on tutorial: https://www.youtube.com/watch?v=7ymQDCIqLjc
// Last edited by Samuel Maturo 3/14/24

public class DissapearingPlatform : MonoBehaviour
{

    public float timeToToggleOn = 3;
    public float timeToToggleOff = 5;
    public float currentTime = 0;
    public bool platformOn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        platformOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToToggleOn && platformOn == false)
        {
            currentTime = 0;
            TogglePlatformOn();
        }
        if (currentTime >= timeToToggleOff)
        {
            currentTime = 0;
            TogglePlatformOff();
        }
    }

    void TogglePlatformOn()
    {
        platformOn = true;
        foreach(Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    void TogglePlatformOff()
    {
        platformOn = false;
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
