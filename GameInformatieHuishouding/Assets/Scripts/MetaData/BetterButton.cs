using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BetterButton : MonoBehaviour, IPointerClickHandler, ISelectHandler, IDeselectHandler
{
    public UnityEvent onLeftClick;
    public UnityEvent onRightClick;
    public UnityEvent onMiddleClick;
    public int speed = 45; // Number of frames to completely interpolate between the 2 positions
    Vector3 startScale;
    Vector3 fullScale;
    bool growing = false;
    bool shrinking = false;
    public bool isSelected = false;

    private void Start()
    {
        startScale = transform.localScale;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //If there is input on any mouse buttons it will send it here
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onLeftClick.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            onRightClick.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            onMiddleClick.Invoke();
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        //Grow(1.08f);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
        //Shrink();
    }


    float tie = 0;
    float sizeIncrease = 1.2f;

    public void Update()
    {
        if (growing)
        {
            tie += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, new Vector3(startScale.x * sizeIncrease, startScale.y * sizeIncrease, startScale.z * sizeIncrease), speed * tie);
            if (transform.localScale.x == sizeIncrease) { growing = false; }
        }
        if (shrinking)
        {
            tie += Time.deltaTime;

            transform.localScale = Vector3.Lerp(fullScale, startScale, speed * tie);
            if (transform.localScale.x == sizeIncrease) { shrinking = false; }
        }
    }

    public void Grow(float size)
    {
        sizeIncrease = size;
        shrinking = false;
        growing = true;
        tie = 0;
    }
    public void Shrink()
    {
        fullScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        sizeIncrease = 1;
        growing = false;
        shrinking = true;
        tie = 0;
    }
}
