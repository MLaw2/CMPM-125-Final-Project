using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTimer;
    public GameObject player;

    private Rigidbody rb;
    private Vector3 playerRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Dash();
        }
    }

    private void Dash()
    {
        playerRotation = transform.rotation.eulerAngles;
        rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
        Invoke(nameof(DashCancel), dashTimer);
    }

    private void DashCancel()
    {
        player.SetActive(false);
        player.SetActive(true);
    }

}
