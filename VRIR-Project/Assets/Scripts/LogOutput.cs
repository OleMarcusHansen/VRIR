using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;

public class LogOutput : MonoBehaviour
{
    [SerializeField] GameObject introScreen;
    [SerializeField] GameObject logOutputScreen;

    [SerializeField] TextMeshPro logText;
    List<string> logStrings = new List<string>();

    [SerializeField] TextMeshProUGUI[] texts;
    int textIndex = 0;

    [SerializeField] List<string> normalStrings = new List<string>();
    [SerializeField] List<string> yellowStrings = new List<string>();
    [SerializeField] List<string> redStrings = new List<string>();

    public bool outputLog = true;
    public bool yellowWarnings;
    public bool redWarnings;

    private void Start()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();

        StartOutput();
    }

    public void StartOutput()
    {

        StartCoroutine("OutputLog");
    }

    IEnumerator OutputLog()
    {
        yield return null;

        while (outputLog)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 1.2f));

            //logStrings.RemoveAt(0);
            AddRandomString();

            //print(string.Join("\n", logStrings));
            //logText.text = string.Join("\n", logStrings);
        }

    }

    void AddRandomString()
    {
        texts[textIndex].transform.SetSiblingIndex(texts.Length - 1);

        if (redWarnings && Random.value > 0.6)
        {
            texts[textIndex].text = redStrings[Random.Range(0, yellowStrings.Count - 1)];
            texts[textIndex].color = Color.red;
        }
        else if (yellowWarnings && Random.value > 0.6)
        {
            texts[textIndex].text = yellowStrings[Random.Range(0, yellowStrings.Count - 1)];
            texts[textIndex].color = Color.yellow;
        }
        else
        {
            texts[textIndex].text = normalStrings[Random.Range(0, normalStrings.Count - 1)];
            texts[textIndex].color = Color.white;
        }


        textIndex++;
        if (textIndex >= texts.Length){
            textIndex = 0;
        }

        /*
        if (yellowWarnings && Random.value > 0.5)
        {
            logStrings.Add(yellowStrings[Random.Range(0, yellowStrings.Count - 1)]);
            return;
        }

        logStrings.Add(normalStrings[Random.Range(0, normalStrings.Count - 1)]);
        */
    }
}
