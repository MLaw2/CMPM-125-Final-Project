using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this;
    }

    private int currentHealth;
    public int maxHealth;

    public float invincibilityLength = 1f;
    private float invincCounter;

    public GameObject[] modelDisplay;
    private float flashCounter;
    public float flashTime = .1f;
    public AudioSource loseHealthSound;

    // Reference to the red flash GameObject
    public GameObject redFlash;

    // Start is called before the first frame update
    void Start()
    {
        FillHealth();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player health is zero or below
        if (currentHealth <= 0)
        {
            // Call a method to handle game over logic if needed
            GameOver();
        }
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                flashCounter = flashTime;

                foreach (GameObject piece in modelDisplay)
                {
                    piece.SetActive(!piece.activeSelf);
                }
            }

            if (invincCounter <= 0)
            {
                foreach (GameObject piece in modelDisplay)
                {
                    piece.SetActive(true);
                }
            }
        }
    }

    public void DamagePlayer()
    {
        if (invincCounter <= 0)
        {
            // Trigger red flash effect
            StartCoroutine(RedFlashEffect());

            invincCounter = invincibilityLength;

            currentHealth--;

            UIController.instance.UpdateHealthDisplay(currentHealth);

            loseHealthSound.Play();
        }
    }

    IEnumerator RedFlashEffect()
    {
        // Activate red flash UI element
        redFlash.SetActive(true);

        // Adjust the duration of the flash
        yield return new WaitForSeconds(0.2f);

        // Deactivate red flash UI element
        redFlash.SetActive(false);
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;

        UIController.instance.UpdateHealthDisplay(currentHealth);
    }

    void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Switch to the "Game Over" scene
        SceneManager.LoadScene("GameOver");
    }
}
