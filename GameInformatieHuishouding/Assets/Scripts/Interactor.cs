using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

interface IInteractable
{
    void Interact();
    string GetInteractionText();
}

public class Interactor : MonoBehaviour
{
    public bool doVoice = true;
    public Transform InteractorTansform;
    public float InteractRange;
    [HideInInspector]
    public TextMeshProUGUI interactionText;
    [HideInInspector]
    public GameObject Crossair;
    private bool isWaiting = false;
    private Coroutine interactionCoroutine;
    public Canvas Canvass;

    [HideInInspector]
    public bool isHovering = false;

    private void Start()
    {
        interactionText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();
        Crossair = GameObject.Find("Crossair");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isWaiting)
            {
                interactionCoroutine = StartCoroutine(WaitAndInteract(0.5f));
            }
        }
        UpdateUI(); // is alleen een functie om de update leesbaar te houden
    }

    IEnumerator WaitAndInteract(float waitTime) // forceerd in kleine cooldown voor interaction
    {
        isWaiting = true;

        Ray ray = new Ray(InteractorTansform.position, InteractorTansform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
        yield return new WaitForSeconds(waitTime);

        isWaiting = false;
    }

    void UpdateUI() // Laat de interaction tekst zien van het geraakte interactable object
    {
        if (interactionText != null)
        {
            Ray ray = new Ray(InteractorTansform.position, InteractorTansform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    isHovering = true;
                    interactionText.text = interactObj.GetInteractionText();
                    if (doVoice)
                       StartCoroutine(Speak());
                    Vector3 direction = hitInfo.point - transform.position;
                    Canvass.transform.position = hitInfo.point - direction.normalized * Vector3.Distance(transform.position, hitInfo.point) / 2;
                    Canvass.transform.rotation = Quaternion.LookRotation(-direction);
                    interactionText.gameObject.SetActive(true);
                    Crossair.gameObject.SetActive(false);
                }
                else
                {
                    Crossair.gameObject.SetActive(true);
                    interactionText.gameObject.SetActive(false);
                    isHovering = false;
                }
            }
            else
            {
                Crossair.gameObject.SetActive(true);
                interactionText.gameObject.SetActive(false);
                isHovering = false;
            }
        }
        else
        {
            Debug.Log("Tektst doet raar");
        }
    }

    private void OnDestroy()
    {
        if (interactionCoroutine != null)
        {
            StopCoroutine(interactionCoroutine);
        }
    }

    IEnumerator Speak()
    {
        doVoice = false;
        TTS.instance.Talk(interactionText.text);
        yield return new WaitForSeconds(3); 
    }
}
