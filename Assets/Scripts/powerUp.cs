using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.name == "Player")
        {
            doubleJump.jumpsRemaining = 2;
            doubleJump.maxJumpCount = 2;
            Destroy(this.gameObject);
        }
    }
}
