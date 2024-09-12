using UnityEngine;

[CreateAssetMenu(fileName = "DocumentData", menuName = "Documents")]
public class DocumentData : ScriptableObject
{
    public Documents.DocumentCategory category; //roep de document data aan
    //diverse categorieen waarin de documenten moet lezen of die mag gearchiveerd mag zijn
    //zie document overzicht arhief en bij te archieveer bij stukken
    public bool differentSys; // andere systeem
    public bool isInternal; // is het intern of ergens anders als het intern is dan false
    public bool isPersonal; // persoonlijk als false is weggooien
    public bool isThirdParty; 
    public bool isCorrenpendence; //correnspondent als true is weggooien
    public bool rightVersion; // de versie die er is gearchiveerd als true is weggooien

    public bool NeedsToBeArchived()
    {
        if (differentSys) return false;
        if (isInternal) return false;
        if (isPersonal) return true;
        if (isCorrenpendence && rightVersion) return true;
        if(rightVersion) return false;

        return false;
        //alle bovenstaande regels moeten gelden voor archiveren 
    }
}
