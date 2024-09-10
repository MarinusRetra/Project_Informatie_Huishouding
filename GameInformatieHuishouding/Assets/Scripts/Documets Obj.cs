using UnityEngine;

public class DocumetsObj : MonoBehaviour
{
    public GameObject[] documets;
    public string documentTitle;
    [TextArea]
    public string documentContent;

    public bool isArchived = false; //bepaalt of de documenten die metadata hebben al zijn gearchiveerd en met dit bool controleert dit

    private void ArchiveDocument()
    {
        string date = System.DateTime.Now.ToString();
        Documents docs = new Documents(documentTitle, documentContent, "Author", date);
        
        //hier moet nog een instansie voor mijn archiefmanager zodat document kan opslaan
            
    }
}
