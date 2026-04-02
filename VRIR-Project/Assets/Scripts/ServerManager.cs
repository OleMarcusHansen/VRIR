using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ServerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject databasePrefab;

    public void InsertDatabase(SelectEnterEventArgs selectEnterEventArgs)
    {
        selectEnterEventArgs.interactableObject.transform.GetComponent<Task>().CompleteTask();
    }

    public void SetText(string s)
    {
        infoText.text = s;
    }

    public void RemoveDatabase(SelectExitEventArgs selectExitEventArgs)
    {
        infoText.text = "<- Insert backup database";
    }

    public void SaveDatabase()
    {
        Instantiate(databasePrefab, spawnPoint);
    }
}
