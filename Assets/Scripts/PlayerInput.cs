using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 move_vector;
    private Rigidbody rbody;
    [SerializeField] private float move_speed;
    [SerializeField] private float jump_strength;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move_vector = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        UnityEngine.Vector3.Normalize(move_vector);
        rbody.AddForce(move_vector * move_speed);


    }
}
