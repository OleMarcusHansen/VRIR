using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Tooltip : MonoBehaviour
{
    [SerializeField] Transform hand;
    [SerializeField] Transform head;

    [SerializeField] TextMeshPro text;

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
            text.text = selectEnterEventArgs.interactableObject.transform.GetComponent<TooltipSelectProvider>().tip;
            gameObject.SetActive(true);
        }
    }

    public void GiveTooltip(HoverEnterEventArgs hoverEnterEventArgs)
    {
        if (hoverEnterEventArgs.interactableObject.transform.GetComponent<TooltipHoverProvider>())
        {
            text.text = hoverEnterEventArgs.interactableObject.transform.GetComponent<TooltipHoverProvider>().tip;
            gameObject.SetActive(true);
        }
    }


    public void ClearTooltip()
    {
        gameObject.SetActive(false);
    }
}
