using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float gravity = 10f;

    [Header("Camera Settings")]
    [SerializeField] private float cameraSpeed = 2f;
    [SerializeField] private float cameraFOV = 45f;

    private CharacterController characterController;
    private Camera playerCamera;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(MovementCoroutine());
        StartCoroutine(JumpCoroutine());
        StartCoroutine(GravityCoroutine());
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

            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator JumpCoroutine()
    {
        while (true)
        {
            if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }

            yield return null;
        }
    }

    private IEnumerator GravityCoroutine()
    {
        while (true)
        {
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
                characterController.Move(moveDirection * Time.deltaTime);
            }

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