using System;
using UnityEngine;

public class InteractLogic : MonoBehaviour
{
    public DocumentData data;

    public void Start()
    {
        string storageLocate = DetermineStorage();
        Debug.Log(storageLocate);
    }

    //game needs to know what data is allowed in each string method
    public string RijksDoc()
    {
        if (data.differentSys == false)
        {
            Debug.Log("not in rijkdoc");
            return "not in rijkdoc system";
        }

        if (data.isInternal == true)
        {
            Debug.Log("in rijkdoc");
            return "in rijkdoc internal";
        }

        return "system";
    } 

    public string NotRijksDox()
    {
        if (data.rightVersion == false)
        {
            Debug.Log("Dit document wordt niet opgeslagen in RijksDoc");
            return "Niet opgeslagen in RijksDoc";
        }

        return "niet opslaan in rijksdoc version";
    }

    public string SaveInTeams()
    {
        if (data.isPersonal == true)
        {
            Debug.Log("Document wordt in Teams opgeslagen");
            return "Bewaar in Teams";
        }
        return "Niet opslaan in Teams";
    }
    public string DetermineStorage()
    {
        // Eerst bepalen waar het document hoort:
        if (data.isPersonal == true)
        {
            return SaveInTeams();  // Bewaar in Teams als het document alleen voor persoonlijk gebruik is
        }
        else if (data.differentSys == false && data.isInternal)
        {
            return RijksDoc();  // Opslaan in RijksDoc als het een intern document is dat niet in een ander systeem staat
        }
        else
        {
            return NotRijksDox();  // Anders, het niet in RijksDoc opslaan
        }
    }
}