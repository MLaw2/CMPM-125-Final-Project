using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Last edited by Matthew Guo on 2/22/24

// PlatformGenerator concept assisted by ChatGPT
public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab of the platform to be generated
    public int numberOfPlatforms; // Number of platforms to generate
    public float levelWidth = 3f; // Width of the area where platforms can spawn
    public float minY = 0.2f; // Minimum height of platforms
    public float maxY = 1.5f; // Maximum height of platforms
    public float horizontalSpacing = 2f; // Horizontal spacing between platforms

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePlatforms()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth) + i * horizontalSpacing;
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
