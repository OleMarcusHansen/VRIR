using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DocumentationOrder : MonoBehaviour
{
    [SerializeField] Task task;

    [SerializeField] XRSocketInteractor detectSlot;
    [SerializeField] XRSocketInteractor containSlot;
    [SerializeField] XRSocketInteractor eradicateSlot;
    [SerializeField] XRSocketInteractor recoverSlot;

    public void CheckOrder()
    {
        if (CheckSlot(detectSlot, 16) && CheckSlot(containSlot, 17) && CheckSlot(eradicateSlot, 18) && CheckSlot(recoverSlot, 19))
        {
            task.CompleteTask();
        }
    }

    bool CheckSlot(XRSocketInteractor slot, int requiredID)
    {
        if (!slot.hasSelection)
        {
            return false;
        }
        if (slot.firstInteractableSelected.transform.GetComponent<Task>().taskID != requiredID)
        {
            return false;
        }

        return true;
    }
}
