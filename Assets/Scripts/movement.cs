using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpImpulse = 7f;
    [SerializeField] private float gravity = 10f;

    [Header("Camera Settings")]
    [SerializeField] private float cameraSpeed = 2f;
    [SerializeField] private float cameraFOV = 60f; // complete misnomer bruh

    private CharacterController characterController;
    private Camera playerCamera;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;

    // parameters for making vertical movement work properly
    [SerializeField] private float verticalVelocity = 0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(MovementCoroutine());
        StartCoroutine(CameraMovementCoroutine());
    }

    private IEnumerator MovementCoroutine()
    {
        while (true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 zVector = transform.forward * verticalInput;
            Vector3 xVector = transform.right * horizontalInput;
            moveDirection = (zVector + xVector).normalized * speed;

            // calculating vertical velocity through gravity and jump impulse
            if (!characterController.isGrounded){
                verticalVelocity -= gravity * Time.deltaTime;
            }
            else {
                verticalVelocity = 0f;
            }
            //if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                verticalVelocity = jumpImpulse;
            }
            moveDirection.y += verticalVelocity;

            //Debug.Log("Vertical Translation: " + moveDirection.y);
            characterController.Move(moveDirection * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator CameraMovementCoroutine()
    {
        while (true)
        {
            float mouseX = Input.GetAxis("Mouse X") * cameraSpeed;
            float mouseY = -Input.GetAxis("Mouse Y") * cameraSpeed;

            rotationX += mouseY;
            rotationX = Mathf.Clamp(rotationX, -cameraFOV, cameraFOV);

            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

            yield return null;
        }
    }
}