using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class FlipPage : MonoBehaviour
{

    public void FlipThePage(GameObject page)
    {
        bool isTrue = !page.transform.GetChild(0).GetChild(0).gameObject.activeSelf;
        for (int i = 0;i < page.transform.GetChild(0).childCount; i++)
        {
            page.transform.GetChild(0).GetChild(i).gameObject.SetActive(isTrue);
        }
        for (int i = 0; i < page.transform.GetChild(1).childCount; i++)
        {
            page.transform.GetChild(1).GetChild(i).gameObject.SetActive(!isTrue);
        }
    }
}
