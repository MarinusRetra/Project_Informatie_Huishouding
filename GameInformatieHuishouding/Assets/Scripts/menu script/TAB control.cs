using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TABcontrol : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Optionsmenu;
    public GameObject Graficsbutton;
    public GameObject TTSButton;
    public GameObject firstmainbutton;
    public GameObject firstOptionsmenu;
    public GameObject firstGraficsbutton;
    public GameObject firstTTSButton;



    // Update is called once per frame
    void Update()
    {
        movebutton();
        moveOptions();
    }

    void movebutton()
    {
        if (MainMenu.SetActive = true)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(MainMenu);
        }
    }

    void moveOptions()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Optionsmenu);
    }
}
