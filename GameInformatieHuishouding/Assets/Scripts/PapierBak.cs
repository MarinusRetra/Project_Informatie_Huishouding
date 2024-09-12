using Unity.VisualScripting;
using UnityEngine;

public class PapierBak : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string opslagNaam;
    Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
    public DocumentGenerator IncomingDocument;

    int attemps = 0;
    int RijksdocFout = 0;
    int NietrijksdocFout = 0;
    int TeamsFout = 0;

    void Start()
    {
        IncomingDocument = GameObject.Find("Player").GetComponent<DocumentGenerator>();
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
        if (opslagNaam == "rijksdocument")
        {
           if(IncomingDocument.Doc != DocumentGenerator.DocType.RijksDoc)
           {
                Debug.Log("Verwachte input was een rijksdoc");
                RijksdocFout++;
           }
           attemps++;
        }
        else if (opslagNaam == "een niet rijksdocument opslag")
        {
           if(IncomingDocument.Doc != DocumentGenerator.DocType.NietRijksDoc)
           {
                Debug.Log("Verwachte input was een niet rijksdoc");
                NietrijksdocFout++;
           }
           attemps++;
        }
        else if (opslagNaam == "teams")
        { 
           if(IncomingDocument.Doc != DocumentGenerator.DocType.Teams)
           {
            Debug.Log("Verwachte input was een teams");
            TeamsFout++;
           }
           attemps++;
        }
        if(attemps >= 10)
        {
            ShowResults();
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
    void ShowResults()
    {
        
        GameObject.Find("Player").GetComponent<Interactor>().interactionText.text = "";
        GameObject.Find("Player").GetComponent<Interactor>().enabled = false;

        Debug.Log("dsasadsadsadsaddsasadsd");
        if(RijksdocFout == 0 && TeamsFout == 0 && NietrijksdocFout == 0)
        {
            IncomingDocument.TitelObject.text = "Goed gedaan!";
            IncomingDocument.TextObject.text = "Je hebt";
            IncomingDocument.AfkomstObject.text = "0";
            IncomingDocument.BestandTypeObject.text = "Fouten";
            IncomingDocument.OndertekendObject.text = "Gemaakt. Lekker bezig!";
        }
        else
        {
            IncomingDocument.TitelObject.text = RijksdocFout == 0 ? "Je hebt geen een fout document in het RijksDoc bakje gestopt. Mooi gedaan!": $"Je hebt {RijksdocFout} documenten in het RijksDoc bakje terwijl ze daar niet thuishoren";
            IncomingDocument.TextObject.text = NietrijksdocFout == 0 ? "Er is geen een onterect bestand beland buiten het NietRijksDoc bakje. Ga zo door!" : $"Je hebt {NietrijksdocFout} documenten in het NietRijksDoc bakje terwijl ze ergens anders horen";
            IncomingDocument.AfkomstObject.text = TeamsFout == 0 ?  "Er is geen foute informatie in het Teams bakje beland. Knap gedaan!": $"Je hebt {TeamsFout} documenten in het Teams bakje gedaan die voor een ander leven ingeschreven stonden";
        }
        GameObject.Find("PapierStapel").GetComponent<Papier>().ViewPaper();
    }
}
    