using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class IsTextCloseEnough : MonoBehaviour
{
    public List<string> actualText;
    private string fullText = "ManIDoNotExist";

    [SerializeField] private GameObject[] topicTextArea;

    [SerializeField] private string[] allTitles;
    [SerializeField] private string[] allTypes;
    [SerializeField] private string[] allCompanies;

    private int amountOfMinigamesDone = 0;
    private float[] prevScore = new float[5];
    private string[] prevName = new string[5];
    private string[] prevGuess = new string[5];

    [SerializeField] private RawImage blackBackground;
    [SerializeField] private GameObject resultsPaper;

    // Start is called before the first frame update
    void Start()
    {
        StartPaperGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckText(string text)
    {
        if(text != "" && text != " ")
        {
            TTS.instance.Talk(text);
            int amountGood = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (i < fullText.Length)
                {
                    if (text[i] == fullText[i])
                    {
                        amountGood++;
                    }
                }
            }

            for (int i = 0; i < actualText.Count; i++)
            {
                if (text.Contains(actualText[i]))
                {
                    int index = 0;
                    for (int j = 0; j < text.Length; j++)
                    {
                        print(actualText[i]);
                        if (actualText[i].Length > 1 && j + 1 != text.Length && text[j] == actualText[i][0] && text[j + 1] == actualText[i][1])
                        {
                            print("Found it! Index: " + j);
                            index = j;
                        }
                    }
                    if (fullText.Length > index)
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

            prevScore[amountOfMinigamesDone] = percent;
            prevName[amountOfMinigamesDone] = fullText;
            prevGuess[amountOfMinigamesDone] = text;
            amountOfMinigamesDone++;

            if (percent > 80)
            {
                print("Good job! You get a cookie! Except you dont!");
            }
            else
            {
                print("BOOOOOO YOU SUCK");
            }
            if (amountOfMinigamesDone > 4)
            {
                for (int i = 0; i < amountOfMinigamesDone; i++)
                {
                    print(prevScore[i]);
                    print(prevGuess[i]);
                    print(prevName[i]);
                }
            }
            else
            {
                StartPaperGame();
            }
        }
        
    }

    public void MakeName()
    {
        fullText = "";
        actualText = new List<string>();
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
        string[] types = { "Titel","Datum", "Organizatie","Type","Versie"};
        int[] sorting = {1,3,0,2,4};
        for (int i = 0; i < 5; i++)
        {
            //Sets the type text
            TMP_Text te = topicTextArea[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            te.text = types[i] + ":";

            //Sets "te" to the other text
            te = topicTextArea[sorting[i]].transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
            if (i == 0)
            {
                te.text = actualText[i].Substring(0, 2);
                te.text += "/";
                te.text += actualText[i].Substring(2, 2);
                te.text += "/";
                te.text += actualText[i].Substring(4, 4);
            }
            else
            {
                te.text = actualText[i];
            }
        }

    }
    public void ReadInfo()
    {
        string fullTalk = "";
        for (int i = 0; i < topicTextArea.Length; i++)
        {
            fullTalk += topicTextArea[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
            fullTalk += "      ";
            fullTalk += topicTextArea[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text;
            fullTalk += "                      ...";
        }
        TTS.instance.Talk(fullTalk);
    }

    public void StartPaperGame()
    {
        MakeName();
        PutOntoPaper();
        ReadInfo();
    }

    public IEnumerator ShowResults()
    {
        blackBackground.color = new Color(0, 0, 0, 0.7f);
        yield return new WaitForSeconds(1);
        resultsPaper.SetActive(true);
    }
}
