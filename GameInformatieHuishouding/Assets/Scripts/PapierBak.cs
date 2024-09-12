using System.Collections;
using UnityEngine;

public class PapierBak : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string opslagNaam;
    Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";


    void Start()
    {
        InteractionScript = GameObject.Find("Player").GetComponent<Interactor>();
    }
    void Update()
    {
        if (InteractionScript.isHovering && InteractionScript.interactionText.text == GetInteractionText())
            OutlineMat.SetFloat(OutlineScale, 1.03f);
        else
            OutlineMat.SetFloat(OutlineScale, 0f);
    }
    public void Interact()
    {
        if (opslagNaam == "rijksdocument ")
        {
            // if papiertje dat je vast hebt gelijk is 

        }
        else if (opslagNaam == " ")
        {
            
        }
        else if (opslagNaam == " ")
        { 
        
        }

        if(opslagNaam == "Lever papier in")
        {
            IsTextCloseEnough clo = FindObjectOfType<IsTextCloseEnough>();
            if(clo.field.text != "" && clo.field.text != " ")
            {
                clo.CheckText(clo.field.text);
            }
            else
            {
                string randomString = "";
                int charAmount = Random.Range(10, 20);
                for (int i = 0; i < charAmount; i++)
                {
                    randomString += glyphs[Random.Range(0, glyphs.Length)];
                }
                clo.CheckText(randomString,false);
            }
        }
        Papier.HoldingPaper = false;
    }

    public string GetInteractionText()
    {
        return Papier.HoldingPaper ? $"{opslagNaam[0].ToString().ToUpper()}{opslagNaam.Substring(1)}" : $"Je hebt geen papier om in {opslagNaam} te stoppen";
    }                                    //pakt de eerste letter van een string en maakt er een hoofdletter
                                         //van en plakt dat weer samen met de rest van de string
}
    