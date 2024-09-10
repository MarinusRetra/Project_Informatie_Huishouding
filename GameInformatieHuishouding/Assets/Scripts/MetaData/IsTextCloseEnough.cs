using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class IsTextCloseEnough : MonoBehaviour
{
    public List<string> actualText;
    private string fullText = "ManIDoNotExist";

    [SerializeField] private GameObject[] topicTextArea;

    [SerializeField] private string[] allTitles;
    [SerializeField] private string[] allTypes;
    [SerializeField] private string[] allCompanies;

    // Start is called before the first frame update
    void Start()
    {
        MakeName();
        PutOntoPaper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckText(string text)
    {
        int amountGood = 0;
        for(int i = 0; i < text.Length; i++)
        {
            if(i < fullText.Length)
            {
                if (text[i] == fullText[i])
                {
                    amountGood++;
                }
            }
        }

        for(int i = 0;i < actualText.Count; i++)
        {
            if (text.Contains(actualText[i]))
            {
                int index = 0;
                for (int j = 0; j < text.Length; j++)
                {
                    if (actualText[i].Length > 1 && text[j] == actualText[i][0] && text[j+1] == actualText[i][1])
                    {
                        print("Found it! Index: " + j);
                        index = j;
                    }
                }
                if(fullText.Length > index)
                {
                    if (actualText[i][0] != fullText[index])
                    {
                        amountGood += actualText[i].Length;
                    }
                    else
                    {
                        print(actualText[i][0] + " / " + fullText[index]);
                    }
                }
            }
        }

        float tot = ((float)fullText.Length) + ((float)fullText.Length - ((float)amountGood)) * 5;
        float percent = (100 / tot) * (float)amountGood;
        print(percent);
        print("Score: " + amountGood + "/" + tot);
    }

    public void MakeName()
    {
        fullText = "";
        int rnd = 0;

        string date = "";
        rnd = Random.Range(1, 29);
        if(rnd < 10) { date += 0; }
        date += rnd;
        rnd = Random.Range(1, 13);
        if (rnd < 10) { date += 0; }
        date += rnd;
        rnd = Random.Range(1980, 2025);
        date += rnd;
        actualText.Add(date);

        rnd = Random.Range(0, allTypes.Length);
        actualText.Add(allTypes[rnd]);

        rnd = Random.Range(0,allTitles.Length);
        actualText.Add(allTitles[rnd]);

        rnd = Random.Range(0, allCompanies.Length);
        actualText.Add(allCompanies[rnd]);

        rnd = Random.Range(1, 20);
        actualText.Add(((float)(rnd) / 10).ToString());
        //Randomz

        for (int i = 0;i < actualText.Count; i++)
        {
            fullText += actualText[i];
            if(i < actualText.Count - 1)
            {
                fullText += " ";
            }
        }
        print(fullText);
    }

    public void PutOntoPaper()
    {
        string[] types = {"Datum","Type","Titel","Organizatie","Versie"};
        for (int i = 0; i < 5; i++)
        {
            //Sets the type text
            TMP_Text te = topicTextArea[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            te.text = types[i] + ":";

            //Sets "te" to the other text
            te = topicTextArea[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
            te.text = actualText[i];
        }

    }
}
