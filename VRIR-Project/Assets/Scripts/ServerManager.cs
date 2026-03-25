using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ServerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;

    public void InsertDatabase(SelectEnterEventArgs selectEnterEventArgs)
    {
        selectEnterEventArgs.interactableObject.transform.GetComponent<Task>().CompleteTask();

        infoText.text = selectEnterEventArgs.interactableObject.transform.GetComponent<Task>().taskName;
    }

    public void RemoveDatabase(SelectExitEventArgs selectExitEventArgs)
    {
        infoText.text = "<- Insert backup database";
    }

    public void RevertDatabase()
    {
        GetComponent<Task>().CompleteTask();
    }
}
