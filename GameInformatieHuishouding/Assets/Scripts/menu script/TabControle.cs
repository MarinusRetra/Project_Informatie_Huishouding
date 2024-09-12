using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TabControle : MonoBehaviour
{
    public List<GameObject> stuff;
    public int currentorder = 0;
    public TTS tts;
    private bool isEnabled = true;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Metadata")
        {
            isEnabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !Input.GetKey(KeyCode.LeftShift) && isEnabled)
        {
            GoToNextStuff(1);
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab) && isEnabled)
        {
            GoToNextStuff(-1);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (stuff[currentorder].GetComponent<Button>() != null)
            {
                stuff[currentorder].GetComponent<Button>().OnSubmit(null);
            }
            if (stuff[currentorder].GetComponent<BetterButton>() != null)
            {
                stuff[currentorder].GetComponent<BetterButton>().onLeftClick.Invoke();
                stuff[currentorder].GetComponent<BetterButton>().onRightClick.Invoke();
            }
            if (stuff[currentorder].GetComponent<TMP_InputField>() != null)
            {
                stuff[currentorder].GetComponent<TMP_InputField>().DeactivateInputField();
                var eventSystem = EventSystem.current;
                eventSystem.SetSelectedGameObject(null);
            }
        }
    }

    public void GoToNextStuff(int offset)
    {
        GameObject lastBtn = stuff[currentorder];
        int beforeOrder = currentorder;
        currentorder += offset;
        for (int i = 0; i < 100; i++)
        {
            if (currentorder > stuff.Count - 1)
            {
                currentorder = 0;
            }else if(currentorder < 0)
            {
                currentorder = stuff.Count - 1;
            }

            if (stuff[currentorder].activeSelf)
            {
                bool isGood = false;
                Transform ob = stuff[currentorder].transform;
                for (int j = 0; j < 100; j++)
                {
                    if (ob.parent != null)
                    {
                        if (ob.parent.gameObject.activeSelf)
                        {
                            ob = ob.parent;
                        }
                        else
                        {
                            currentorder += offset;
                            j = 100;
                        }
                    }
                    else
                    {
                        j = 100;
                        isGood = true;
                    }
                }
                if (isGood)
                {
                    i = 100;
                }
            }
            else
            {
                currentorder += offset;

            }
            if(i == 99)
            {
                currentorder = beforeOrder;
            }
        }
        string read = "";
        if (stuff[currentorder].GetComponent<Button>() != null)
        {
            stuff[currentorder].GetComponent<Image>().color = new Color(118f / 255f, 210f / 255f, 182f / 255f, 100);
            read = stuff[currentorder].transform.GetChild(0).GetComponent<TMP_Text>().text;
        }
        if (stuff[currentorder].GetComponent<TMP_Text>() != null)
        {
            read = stuff[currentorder].GetComponent<TMP_Text>().text;
        }
        if (stuff[currentorder].GetComponent<TMP_InputField>() != null)
        {
            read = "Input Field";
            stuff[currentorder].GetComponent<TMP_InputField>().ActivateInputField();
        }

        if (lastBtn.GetComponent<Button>() != null)
        {
            lastBtn.GetComponent<Image>().color = new Color(255, 255, 255, 100);
        }

        TTS.instance.Talk(read);
        print(stuff[currentorder].name);
        
    }

    public void canUse(bool canUse)
    {
        isEnabled = canUse;
    }
}
