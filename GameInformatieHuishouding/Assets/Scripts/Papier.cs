using System;
using System.Collections;
using UnityEngine;

public class Papier : MonoBehaviour, IInteractable
{
    bool HoldingPaper = true;

    public Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (InteractionScript.isHovering)
        {
            OutlineMat.SetFloat(OutlineScale, 1.03f);
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
        if (HoldingPaper)
        {
            animator.Play("Pak");
        }
        else
            animator.Play("Leg");

        StartCoroutine(WaitAndDisable());
    }

    public string GetInteractionText()
    {
        return HoldingPaper ? "Pak papier" : "Leg papier neer";

    }
}
