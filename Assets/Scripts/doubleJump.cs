using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float jumpHeight = 10f;
    public bool isGrounded;

    public static int maxJumpCount = 1;
    public static int jumpsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || jumpsRemaining > 0)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);
        playerRigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        jumpsRemaining--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            jumpsRemaining = maxJumpCount;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}