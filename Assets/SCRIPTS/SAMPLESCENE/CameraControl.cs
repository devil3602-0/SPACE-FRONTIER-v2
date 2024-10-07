using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody; // Reference to the player's body (to rotate it with the camera)
    public float mouseSensitivity = 100f; // Sensitivity of mouse movement

    float xRotation = 0f; // Tracks the vertical rotation of the camera

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the mouse input for rotation (x and y axes)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply vertical rotation (for looking up and down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation

        // Apply the rotation to the camera and player body
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Camera rotation for looking up/down
        playerBody.Rotate(Vector3.up * mouseX); // Rotate the player body with the camera for horizontal movement
    }
}
