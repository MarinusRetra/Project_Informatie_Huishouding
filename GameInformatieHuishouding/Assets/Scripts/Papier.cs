using UnityEngine;

public class Papier : MonoBehaviour, IInteractable
{
    public static bool HoldingPaper = false;

    Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;
    GameObject PapierObject;
    public bool canLetDown = true;

    void Start()
    {
        InteractionScript = GameObject.Find("Player").GetComponent<Interactor>();
        PapierObject = GameObject.Find("PaperObject");
        PapierObject.SetActive(false);
        HoldingPaper = false;
    }
    void Update()
    {
        if(HoldingPaper)
        {
            if (Input.GetKeyDown(KeyCode.R) && canLetDown)
                ViewPaper();
        }

        if (PapierObject.activeSelf && !HoldingPaper)
        {
            PapierObject.SetActive(false);
            Camera.ToggleCameraLock();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (InteractionScript.isHovering && InteractionScript.interactionText.text == GetInteractionText())
            OutlineMat.SetFloat(OutlineScale, 1.05f);
        else
            OutlineMat.SetFloat(OutlineScale, 0f);
    }
    public void Interact()
    {
       HoldingPaper = true;
    }

    public string GetInteractionText()
    {
        return HoldingPaper ? "Leg eerst je oude papier weg" : "Pak papier 'E' ";
    }

    void ViewPaper()
    {
        Camera.ToggleCameraLock();
        Cursor.visible = !Cursor.visible;
        PapierObject.SetActive(!PapierObject.activeSelf);

        if (PapierObject.activeSelf)
        {
            FindAnyObjectByType<IsTextCloseEnough>().ReadInfo();
            Cursor.lockState = CursorLockMode.None;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetCanLetDown(bool canLet)
    {
        canLetDown = canLet;
    }
}
