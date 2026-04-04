using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Tooltip : MonoBehaviour
{
    [SerializeField] Transform hand;
    [SerializeField] Transform head;

    [SerializeField] TextMeshPro text;

    bool isHover;

    void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.position = hand.position;
            transform.LookAt(head);
        }
    }

    public void GiveTooltip(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactableObject.transform.GetComponent<TooltipSelectProvider>())
        {
            if (selectEnterEventArgs.interactableObject.transform.GetComponent<TooltipSelectProvider>().enabled)
            {
                text.text = selectEnterEventArgs.interactableObject.transform.GetComponent<TooltipSelectProvider>().tip;
                gameObject.SetActive(true);
                isHover = false;
            }
        }
    }

    public void GiveTooltip(HoverEnterEventArgs hoverEnterEventArgs)
    {
        if (hoverEnterEventArgs.interactableObject.transform.GetComponent<TooltipHoverProvider>())
        {
            if (hoverEnterEventArgs.interactableObject.transform.GetComponent<TooltipHoverProvider>().enabled)
            {
                text.text = hoverEnterEventArgs.interactableObject.transform.GetComponent<TooltipHoverProvider>().tip;
                gameObject.SetActive(true);
                isHover = true;
            }
        }
    }


    public void ClearTooltip(bool hover)
    {
        if (isHover == hover)
        {
            gameObject.SetActive(false);
            hover = false;
        }
    }
}
