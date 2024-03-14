using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementTracker : MonoBehaviour
{
    public static AchievementTracker instance;  // I want other objects/scripts to be able to access this and add an achievement whenever
    [SerializeField] private float achievementDisplayTime = 5;
    [SerializeField] private GameObject achievementDisplayObject;
    [SerializeField] private TMP_Text achievementTitleField;
    [SerializeField] private TMP_Text achievementMessageField;
    private ArrayList achievementList;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
        achievementList = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DisplayAchievement()
    {
        achievementDisplayObject.SetActive(true);
        yield return new WaitForSeconds(achievementDisplayTime);
        achievementDisplayObject.SetActive(false);
    }

    // call achievement
    public void GiveAchievement(string achievementName, string achievementDescription) {
        if (achievementList.BinarySearch(achievementName) < 0) {
            achievementTitleField.text = achievementName;
            achievementMessageField.text = achievementDescription;
            StartCoroutine("DisplayAchievement");
            achievementList.Add(achievementName);
        }
    }
}
