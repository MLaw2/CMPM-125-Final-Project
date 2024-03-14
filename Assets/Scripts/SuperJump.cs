using UnityEngine;

public class SuperJump : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    public ParticleSystem jumpParticles; // Reference to the particle system
    public AudioSource jumpSound;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            // Play the particle system
            if (jumpParticles != null)
            {
                jumpParticles.Play();
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")&& Input.GetKey(jumpKey))
        {
            jumpParticles.Play();
            jumpSound.Play();
        }
    }
}
