using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAchievement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            AchievementTracker.instance.GiveAchievement("You Found ME!", "whoa! How'd you get up here");

            Destroy(this.gameObject);
        }
    }
}
