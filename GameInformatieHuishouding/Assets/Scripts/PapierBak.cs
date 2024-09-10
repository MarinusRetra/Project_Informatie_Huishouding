using System.Collections;
using UnityEngine;

public class PapierBak : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string opslagNaam;
    public Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;

    void Update()
    {
        if (InteractionScript.isHovering)
        {
            OutlineMat.SetFloat(OutlineScale, 1.05f);
        }
        else
            OutlineMat.SetFloat(OutlineScale, 0f);
    }
    public void Interact()
    {
        Papier.HoldingPaper = false;
    }

    public string GetInteractionText()
    {
        return Papier.HoldingPaper ? $"{opslagNaam[0].ToString().ToUpper()}{opslagNaam.Substring(1)}" : $"Je hebt geen papier om in {opslagNaam} te stoppen";
    }                                    //pakt de eerste letter van een string en maakt er een hoofdletter
                                         //van en plakt dat weer samen met de rest van de string
}
    