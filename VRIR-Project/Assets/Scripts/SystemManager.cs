using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SystemManager : MonoBehaviour
{
    public void InsertConfig(SelectEnterEventArgs selectEnterEventArgs)
    {
        selectEnterEventArgs.interactableObject.transform.GetComponent<Task>().CompleteTask();
    }
}
