using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public bool scenarioStarted;

    [SerializeField] string[] scenarioExecutionFlowCorrect;
    [SerializeField] List<string> scenarioExecutionFlowPerformed = new List<string>();

    [SerializeField] int secondsUntilYellowWarnings;
    [SerializeField] int secondsUntilRedWarnings;

    [SerializeField] LogOutput logOutput;
    [SerializeField] GameObject startScreen;

    [SerializeField] ResultsManager resultsManager;

    public static ScenarioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Two ScenarioManagers exist in the same scene");
        }
    }

    public void AddPerformedTask(string taskName)
    {
        scenarioExecutionFlowPerformed.Add(taskName);
    }

    public void StartScenario()
    {
        if (scenarioStarted)
        {
            return;
        }

        StartCoroutine("Scenario");

        scenarioStarted = true;
    }

    IEnumerator Scenario()
    {
        if (scenarioStarted)
        {
            yield break;
        }

        // start normal log output
        logOutput.gameObject.SetActive(true);
        startScreen.gameObject.SetActive(false);
        logOutput.StartOutput();

        yield return new WaitForSeconds(secondsUntilYellowWarnings);

        // start yellow warning output
        logOutput.yellowWarnings = true;

        yield return new WaitForSeconds(secondsUntilRedWarnings);

        // start red warning output
        logOutput.yellowWarnings = false;
        logOutput.databaseWarnings = true;
        logOutput.redWarnings = true;
    }

    public void EndScenario()
    {
        logOutput.EndOutput();

        // calculate and show score and feedback
        resultsManager.CreateMenu(scenarioExecutionFlowCorrect, scenarioExecutionFlowPerformed.ToArray());

        // present menu to quit or restart scenario
    }
}
