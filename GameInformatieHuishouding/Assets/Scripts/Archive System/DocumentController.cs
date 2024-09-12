using TMPro;
using UnityEngine;

public class DocumentController : MonoBehaviour
{
    public DocumentData data;
    public TextMeshProUGUI result;

    public void CheckArchiving()
    {
        bool shouldArchive = data.NeedsToBeArchived();
        result.text = shouldArchive? "Archiving..." : "Not Archiving...";
    }
}
