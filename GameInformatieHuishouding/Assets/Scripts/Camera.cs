using System;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static bool BlindMode = false;

    [SerializeField]
    List<GameObject> InteractableObjects;
    [SerializeField]
    int selectedObject = -1;
    public static bool camLocked { get; private set; }

    public float mouseSensivity = 500f;

    public Transform Player;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        //stopt alle interactable objects in een list
        InteractableObjects = GrabInteractableObjects();

        camLocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (BlindMode)
        { 
            if (Input.GetKeyDown(KeyCode.Tab) && !Input.GetKey(KeyCode.LeftShift) && selectedObject < InteractableObjects.Count-1)
            {
                selectedObject++;
                Player.LookAt(InteractableObjects[selectedObject].transform);
            }
            if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift) && selectedObject > 0)
            {
                selectedObject--;
                Player.LookAt(InteractableObjects[selectedObject].transform);
            }
        }
        if (!BlindMode)
        { 
            float mouseX = -Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Math.Clamp(xRotation, -90f, 90f);

            yRotation -= mouseX;
            yRotation = Math.Clamp(yRotation, -90f, 90f);

            if (!camLocked)
            { 
                transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
                Player.Rotate(Vector3.up * mouseX);
            }
        }
    }

    public static void ToggleCameraLock()
    { 
        Cursor.visible = camLocked;
        camLocked = !camLocked;
    }
    /// <summary>
    /// Pakt alle interactable objects en stopts ze in de list
    /// </summary>
    List<GameObject> GrabInteractableObjects()
    {
        List<GameObject> Interactables = new();
        GameObject InteractablesObjects = GameObject.Find("InteractableObjects");

        foreach (Transform child in InteractablesObjects.GetComponentInChildren<Transform>())
        {
            Interactables.Add(child.gameObject);
        }
        return Interactables;
    }
}
