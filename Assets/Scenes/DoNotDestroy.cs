using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMusicPlaying = false;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            if (audioSource != null && isMusicPlaying)
            {
                audioSource.Stop();
                isMusicPlaying = false;
            }
        }
        else if (scene.name == "GameOver" || scene.name == "MainMenu")
        {
            if (audioSource != null && !isMusicPlaying)
            {
                audioSource.Play();
                isMusicPlaying = true;
            }
        }
    }
}
