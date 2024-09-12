using UnityEngine;

public class Papier : MonoBehaviour, IInteractable
{
    public static bool HoldingPaper = false;

    Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;
    GameObject PapierObject;

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
            if (Input.GetKeyDown(KeyCode.R))
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
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }
}
