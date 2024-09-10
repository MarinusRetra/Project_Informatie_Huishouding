using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeDoc : MonoBehaviour
{
    [SerializeField] private int[] minAndMaxAmountMissing = { 0, 1 };
    [SerializeField] readonly private string[] allTopics = {"Names","Made By"};

    [SerializeField] private List<string> currentSpawningTopics;
    [SerializeField] private GameObject[] topicTextArea;

    [SerializeField] private string[] allNames;
    [SerializeField] private string[] allMadeBy;
    private void Start()
    {
        GenerateMissing();
    }
    public void GenerateMissing()
    {
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

            //Chooses the array based on the topic
            switch(currentSpawningTopics[i])
            {
                case "Names":
                    options = allNames;
                    break;
                case "Made By":
                    options = allMadeBy;
                    break;
            }

            //Sets the type text
            TMP_Text te = topicTextArea[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            te.text = currentSpawningTopics[i] + ":";

            //Chooses a random
            rnd = Random.Range(0,options.Length);

            //And sets the text to it
            te = topicTextArea[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
            te.text = options[rnd];
        }
        print(currentSpawningTopics.Count);
    }

    public void GenerateMust()
    {

    }
}
