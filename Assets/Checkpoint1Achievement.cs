using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1Achievement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AchievementTracker.instance.GiveAchievement("Checkpoint 1", "wasnt too hard right?");

            
        }
    }
}
