using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DocumentGenerator : MonoBehaviour
{
    public enum DocType { NietRijksDoc, Teams, RijksDoc }
    public DocType Doc { get; private set; }
    public TextMeshProUGUI TitelObject;
    public TextMeshProUGUI TextObject;
    public TextMeshProUGUI AfkomstObject;
    public TextMeshProUGUI BestandTypeObject;
    public TextMeshProUGUI OndertekendObject;
    public List<string> Titel { get; private set; }
    public List<string> Text { get; private set; }
    public List<string> Afkomst { get; private set; }
    public List<string> BestandType { get; private set; }
    public bool Ondertekend { get; private set; }
    public string[] Handtekeningen { get; private set; } = { "Handtekening: _________/\\/\\/\\/\\_____/\\/\\___/\\/\\______", "Handtekening: _________ /\\/\\/\\/\\___", "Handtekening: _/\\/\\___/\\/\\___" };

    public void PickDocument()
    { 
        System.Array vals = System.Enum.GetValues(typeof(DocType));
        Doc = (DocType)vals.GetValue(Random.Range(0, vals.Length));
        GenerateDocument();
    }

    private void Start()
    {
        PickDocument();
    }
    void GenerateDocument()
    { 
        if (Doc == DocType.NietRijksDoc)
        {
            Titel = new List<string>() { "Aantekeningen wiskunde", "Uitnodiging personeelsfeest", "Meubel kortingcodes" };
            Text = new List<string>() { "10 redenen waarom gele sneeuw eten een slecht idee is\n-opgeslagen in ander systeem", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "Super interessante maar verder onbelangrijke informatie" };
            Afkomst = new List<string>() { "The Coca-Cola Company", "Willy Wonka", "Tante Truus" };
            BestandType = new List<string>() { "Mail", "WhatsApp log", "Folder", "JPEG" };
            Ondertekend = false;
        }
        else if (Doc == DocType.RijksDoc)
        {
            Titel = new List<string>() { "Ontwikkelings plan website", "Systeem test 07/11/2024", "Begroting 2023", "Advies", "Brief" };
            Text = new List<string>() { "Inkomsten: Te laag\nUitgaven: Te hoog", "Test resultaat: :)", "Een goede manier werken staat hier beschreven", "Belangrijke en goedgekeurde informatie" };
            Afkomst = new List<string>() { "DICTU" };
            BestandType = new List<string>() { ".TXT", ".PDF", ".xlsx" };
            Ondertekend = Random.value < 0.2f;
        }
        else // als het een teams bestemd bestand is
        {
            Titel = new List<string>() { "Concept website", "Design concept", "Concept verbetering cloud werkplek" };
            Text = new List<string>() { "Stap 1 maak. \nStap 2 klaar", "Een verzameling toffe idee�n", "Een gestructureerd en duidelijk plan" };
            Afkomst = new List<string>() { "DICTU" };
            BestandType = new List<string>() { "WordDocument", "Foto", ".txt", "PDF" };
            Ondertekend = false;
        }
        TitelObject.text = $"Titel: {Titel[Random.Range(0, Titel.Count)]}";
        
        if (TitelObject.text != "Systeem test 07/11/2024")
        {
            Text.Remove("Test resultaat: :)");
        }
        if(TitelObject.text != "Begroting 2023")
        {
            Text.Remove("Inkomsten: Te laag\nUitgaven: Te hoog");
        }
        TextObject.text = $"{Text[Random.Range(0, Text.Count)]}";

        AfkomstObject.text = $"Afkomst: {Afkomst[Random.Range(0, Afkomst.Count)]}";
        BestandTypeObject.text = $"BestandType: {BestandType[Random.Range(0, BestandType.Count)]}";
        OndertekendObject.text = Ondertekend ? $"Ondertekening: {Handtekeningen[Random.Range(0, Handtekeningen.Length)]}" : " ";
        
        if (TitelObject.text == "Begroting 2023")
        {
            TextObject.text = "\"Inkomsten: Te laag\\nUitgaven: Te hoog";
        }
    }
}
