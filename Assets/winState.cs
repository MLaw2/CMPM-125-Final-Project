using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winState : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the object tagged as "EndObject"
        if (other.CompareTag("Player"))
        {
            // Call the function to transition to the EndScene
            EndGame();
        }
    }

    private void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Load the EndScene
        SceneManager.LoadScene("EndScreen");
    }
}
