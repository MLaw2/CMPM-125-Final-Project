// using System.Collections;
// using System.Collections.Generic;
// using System.Numerics;
// using UnityEngine;

// // This script was found from below source:
// // https://www.youtube.com/watch?v=W70n_bXp7Dc

// public class cameraMovement : MonoBehaviour
// {
//     float rotationX = 0f;
//     float rotationY = 0f;
//     public float sensitivity = 15f;

//     // Update is called once per frame
//     void Update()
//     {
//         rotationY += Input.GetAxis("Mouse X") * sensitivity;
//         rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
//         transform.localEulerAngles = new UnityEngine.Vector3(rotationX, rotationY, 0);
//     }
// }
