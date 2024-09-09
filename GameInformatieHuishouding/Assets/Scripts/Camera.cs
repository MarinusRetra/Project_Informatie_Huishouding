using System;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensivity = 500f;

    public Transform Player;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = -Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);

        yRotation -= mouseX;
        yRotation = Math.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        Player.Rotate(Vector3.up * mouseX);

    }
}
