using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeDoc : MonoBehaviour
{
    [SerializeField] private int[] minAndMaxAmountMissing = { 0, 1 };
    [SerializeField] readonly private string[] allTopics = {"Names","Made By","Made On","Result Type", "Catogory","Vindplaats"};

    [SerializeField] private List<string> currentSpawningTopics;
    [SerializeField] private GameObject[] topicTextArea;

    [SerializeField] private string[] allNames;
    [SerializeField] private string[] allMadeBy;
    [SerializeField] private string[] allResultTypes;
    [SerializeField] private string[] allCatogories;
    [SerializeField] private string[] allFoundLocations;
    private void Start()
    {
        GenerateMissing();
    }
    public void GenerateMissing()
    {
        for (int i = 0; i < topicTextArea.Length; i++)
        {
            topicTextArea[i].gameObject.SetActive(false);
        }

        //Puts all the topics into currentSpawningTopics
        currentSpawningTopics = new List<string>(allTopics);

        //Removes a random amount
        int rnd = Random.Range(minAndMaxAmountMissing[0], minAndMaxAmountMissing[1]);

        for(int i = 0;i < rnd;i++) 
        {
            int rand = Random.Range(0, currentSpawningTopics.Count);
            currentSpawningTopics.RemoveAt(rand);
        }

        //Has the next few topics choose a random text
        for(int i = 0; i < currentSpawningTopics.Count; i++)
        {
            string[] options = {"Failure."};
            bool needsArray = true;

            //Chooses the array based on the topic
            switch(currentSpawningTopics[i])
            {
                case "Names":
                    options = allNames;
                    break;
                case "Made By":
                    options = allMadeBy;
                    break;
                case "Made On":
                    needsArray = false;
                    string date = "";
                    rnd = Random.Range(1, 29);
                    date += rnd + "/";
                    rnd = Random.Range(1, 13);
                    date += rnd + "/";
                    rnd = Random.Range(1980, 2025);
                    date += rnd;
                    options[0] = date;
                    break;
                case "Result Type":
                    options = allResultTypes;
                    break;
                case "Vindplaats":
                    options = allFoundLocations;
                    break;
                case "Catogory":
                    options = allCatogories;
                    break;
            }

            //Sets the type text
            TMP_Text te = topicTextArea[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            te.text = currentSpawningTopics[i] + ":";

            //Sets "te" to the other text
            te = topicTextArea[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>();

            //Some topics have a different type of random
            if (needsArray)
            {
                //Chooses a random
                rnd = Random.Range(0, options.Length);

                //And sets the text to it
                te.text = options[rnd];
            }
            else
            {
                te.text = options[0];
            }
        }

        for(int i = 0; i < topicTextArea.Length; i++)
        {
            if(topicTextArea[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text != "Nil")
            {
                topicTextArea[i].gameObject.SetActive(true);
            }
        }
        print(currentSpawningTopics.Count);
    }

    public void GenerateMust()
    {

    }
}
