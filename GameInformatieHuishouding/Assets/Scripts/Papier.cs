using System.Collections;
using UnityEngine;

public class Papier : MonoBehaviour, IInteractable
{
    bool HoldingPaper = false;

    public Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;
    public GameObject PapierObject;

    void Update()
    {
        if(HoldingPaper)
        {
            if (Input.GetKeyDown(KeyCode.E))
                ViewPaper();
        }

        if (InteractionScript.isHovering)
        {
            OutlineMat.SetFloat(OutlineScale, 1.05f);
        }
        else
            OutlineMat.SetFloat(OutlineScale, 0f);
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(0.8f);
        HoldingPaper = !HoldingPaper;
    }

    public void Interact()
    {
        if (!HoldingPaper)
        {
            ViewPaper();
            StartCoroutine(WaitAndDisable());
        }
    }

    public string GetInteractionText()
    {
        return HoldingPaper ? "Leg eerst je oude papier weg" : "Pak papier 'E' ";
    }

    void ViewPaper()
    {
        Camera.ToggleCameraLock();
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = CursorLockMode.Confined;
        PapierObject.SetActive(!PapierObject.activeSelf);

        if (PapierObject.activeSelf)
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }
}
