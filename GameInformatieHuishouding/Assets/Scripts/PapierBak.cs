using UnityEngine;
using UnityEngine.UI;
public class PapierBak : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string opslagNaam;  // Naam van de bak
    Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;
    public Text notificationText;  // UI Text component voor meldingen aan de speler

    void Start()
    {
        InteractionScript = GameObject.Find("Player").GetComponent<Interactor>();
    }

    void Update()
    {
        if (InteractionScript.isHovering)
            OutlineMat.SetFloat(OutlineScale, 1.05f);  // Highlight de bak als je eroverheen beweegt
        else
            OutlineMat.SetFloat(OutlineScale, 0f);  // Zet de highlight uit
    }

    public void Interact()
    {
        if (Papier.HoldingPaper)
        {
            print(opslagNaam);

            GameObject target = null;
            
            if (opslagNaam == "RijksDocument")
            {
                target = GameObject.FindWithTag("Rijksdocument");
            }
            else if (opslagNaam == "NietRijksdocument")
            {
                target = GameObject.FindWithTag("NietRijksdocument");
            }
            else if (opslagNaam == "Teams")
            {
                target = GameObject.FindWithTag("Teams");
            }
            else
            {
                Debug.Log("Geen bak gevonden");
            }

            if (target != null)
            {
                Debug.Log($"Papier gearchiveer op: {target.name}");
                if (notificationText != null)
                {
                    notificationText.text = $"Papier gearchiveer op: {target.name}";
                }
            }
            Papier.HoldingPaper = false;
        }
        else
        {
            Debug.Log("Je hebt geen papier om in de bak te stoppen");
        }
    }

    public string GetInteractionText()
    {
        return Papier.HoldingPaper ? $"{opslagNaam[0].ToString().ToUpper()}{opslagNaam.Substring(1)}" : $"Je hebt geen papier om in {opslagNaam} te stoppen";
    }
}