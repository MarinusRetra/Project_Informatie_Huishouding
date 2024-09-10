[System.Serializable]
public class Documents
{
    public string titleName;
    public string contents;
    public string author;
    public string date;
    //het maken voor informatie om het hergebruiken van de class
    // vul aan welk data er meer in moet

    public Documents(string titleName, string contents, string author, string date)
    {
        this.titleName = titleName;
        this.contents = contents;
        this.author = author;
        this.date = date;
    }
}
