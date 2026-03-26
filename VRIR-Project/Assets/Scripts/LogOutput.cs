using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogOutput : MonoBehaviour
{
    [SerializeField] Transform verticalLayout;
    TextMeshProUGUI[] texts;
    int textIndex = 0;

    [SerializeField] List<string> normalStrings = new List<string>();
    [SerializeField] List<string> yellowStrings = new List<string>();
    [SerializeField] List<string> databaseStrings = new List<string>();
    [SerializeField] List<string> redStrings = new List<string>();

    bool outputLog = true;
    public bool yellowWarnings;
    public bool redWarnings;

    public bool databaseWarnings;

    [SerializeField] AlarmManager alarmManager;

    private void Start()
    {
        texts = verticalLayout.GetComponentsInChildren<TextMeshProUGUI>();
    }

    public void StartOutput()
    {
        StartCoroutine("OutputLog");
    }
    public void EndOutput()
    {
        outputLog = false;
    }

    public void StartDatabaseWarnings()
    {
        databaseWarnings = true;
    }
    public void StopDatabaseWarnings()
    {
        databaseWarnings = false;
    }
    public void StopYellowWarnings()
    {
        yellowWarnings = false;
    }
    public void StopRedWarnings()
    {
        redWarnings = false;
    }

    IEnumerator OutputLog()
    {
        yield return null;

        while (outputLog)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));

            AddRandomString();
        }

    }

    public void AddString(string s)
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        texts[textIndex].transform.SetSiblingIndex(texts.Length - 1);

        texts[textIndex].text = s;
        texts[textIndex].color = Color.green;

        textIndex++;
        if (textIndex >= texts.Length){
            textIndex = 0;
        }
    }

    void AddRandomString()
    {
        texts[textIndex].transform.SetSiblingIndex(texts.Length - 1);

        if (redWarnings && Random.value > 0.6)
        {
            texts[textIndex].text = redStrings[Random.Range(0, yellowStrings.Count)];
            texts[textIndex].color = Color.red;

            // trigger alarm light
            alarmManager.PlayAlarms(red:true);
        }
        else if (yellowWarnings && Random.value > 0.6)
        {
            texts[textIndex].text = yellowStrings[Random.Range(0, yellowStrings.Count)];
            texts[textIndex].color = Color.yellow;

            // trigger alarm light
            alarmManager.PlayAlarms(red:false);
        }
        else if (databaseWarnings && Random.value > 0.6)
        {
            texts[textIndex].text = databaseStrings[Random.Range(0, databaseStrings.Count)];
            texts[textIndex].color = Color.yellow;

            // trigger alarm light
            alarmManager.PlayAlarms(red: false);
        }
        else
        {
            texts[textIndex].text = normalStrings[Random.Range(0, normalStrings.Count)];
            texts[textIndex].color = Color.white;
        }

        textIndex++;
        if (textIndex >= texts.Length){
            textIndex = 0;
        }
    }
}
