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
        
    Interactor interactor;
    public static bool camLocked { get; private set; }

    public float mouseSensivity = 500f;

    public Transform Player;

    float xRotation = 0f;
    float yRotation = 0f;
    private bool canTab = true;

    void Start()
    {

        //stopt alle interactable objects in een list
        InteractableObjects = GrabInteractableObjects();

        interactor = GameObject.Find("Player").GetComponent<Interactor>();

        camLocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (BlindMode)
        { 
            if (Input.GetKeyDown(KeyCode.Tab) && !Input.GetKey(KeyCode.LeftShift) && canTab)
            {
                interactor.doVoice = true;
                selectedObject++;
                if (selectedObject == InteractableObjects.Count)
                    selectedObject = 0;
                Player.LookAt(InteractableObjects[selectedObject].transform);
            }
            if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift) && canTab)
            {
                interactor.doVoice = true;
                selectedObject--;
                if (selectedObject < 0)
                    selectedObject = InteractableObjects.Count - 1;
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
            Interactables.Add(child.gameObject);

        return Interactables;
    }

    public void SwitchCanTab(bool can)
    {
        canTab = can;
    }
}
