using System.Collections.Generic;
using UnityEngine;

public class DocumentGenerator : MonoBehaviour
{
    protected enum DocType {NietRijksDoc, Teams, RijksDoc}
    protected DocType doc;

    public DocumentGenerator()
    {
        System.Array vals = System.Enum.GetValues(typeof(DocType));
        doc = (DocType)vals.GetValue(Random.Range(0,vals.Length));
    }
}

class GeneratingDocument : DocumentGenerator
{
    public List<string> Titel {get; private set;}
    public List<string> Text {get; private set;}
    public List<string> Afkomst {get; private set;}
    public List<string> BestandType {get; private set;}
    public bool ondertekend { get; private set;}
    public GeneratingDocument()
    {
        if (doc == DocType.NietRijksDoc)
        {
            Titel = new List<string>() {"Aantekeningen wiskunde", "Uitnodiging personeelsfeest","Meubel kortingcodes"};
            Text = new List<string>() { "10 redenen waarom gele sneeuw eten een slecht idee is\n-opgeslagen in ander systeem", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "Super interessante maar verder onbelangrijke informatie"};
            Afkomst = new List<string>() { "The Coca-Cola Company", "Willy Wonka", "Tante Truus"};
            BestandType = new List<string>() { "Mail","WhatsApp log","Folder","JPEG"};
            ondertekend = false;
        }
        else if (doc == DocType.RijksDoc)
        {
            Titel = new List<string>() { "Ontwikkelings plan website", "Systeem test 07/11/2024", "Begroting 2023", "Advies", "Systeem documentatie" };
            Text = new List<string>() { "Inkomsten: Te laag\nUitgaven:", "", "" };
            Afkomst = new List<string>() { "DICTU", "", "" };
            BestandType = new List<string>() { "", "", ""};
            ondertekend = Random.value < 0.2f;
        }
        else // als het een teams bestemd bestand is
        {
            Titel = new List<string>() { "Concept website", "Design concept", "Concept verbetering cloud werkplek" };
            Text = new List<string>() { "Stap 1 maak. \nStap 2 klaar", "Een verzameling toffe ideeën", "Een gestructureerd en duidelijk plan" };
            Afkomst = new List<string>() { "DICTU"};
            BestandType = new List<string>() { "WordDocument", "Foto", ".txt", "PDF" };
            ondertekend = false;
        }
    }
}
