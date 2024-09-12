using UnityEngine;

[CreateAssetMenu(fileName = "DocumentData", menuName = "Documents")]
public class DocumentData : ScriptableObject
{
    public enum DocumentCategory
    {
        SignedDocument,
        Policy,
        Contract,
        Organizational,
        Financial,
        ExternalCommunication,
        WooRequests,
        ThirdParty
    }

    public DocumentCategory category;
    public bool differentSys;
    public bool isInternal;
    public bool isPersonal;
    public bool isCorrespondence;
    public bool rightVersion;

    public bool NeedsToBeArchived()
    {
        if (differentSys) return false;
        if (isInternal) return true;
        if (isPersonal) return true;
        if (isCorrespondence && rightVersion) return true;
        if (rightVersion) return false;

        return false;
    }
}