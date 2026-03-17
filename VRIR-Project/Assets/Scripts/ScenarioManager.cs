using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public bool ScenarioStarted;

    [SerializeField] string[] scenarioExecutionFlowCorrect;
    [SerializeField] List<string> scenarioExecutionFlowPerformed = new List<string>();

    [SerializeField] int secondsUntilYellowWarnings;
    [SerializeField] int secondsUntilRedWarnings;

    [SerializeField] LogOutput logOutput;
    [SerializeField] GameObject startScreen;

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
        StartCoroutine("Scenario");
    }

    IEnumerator Scenario()
    {
        if (ScenarioStarted)
        {
            yield break;
        }

        // start normal log output
        logOutput.gameObject.SetActive(true);
        logOutput.StartOutput();

        yield return new WaitForSeconds(secondsUntilYellowWarnings);

        // start yellow warning output
        logOutput.yellowWarnings = true;

        yield return new WaitForSeconds(secondsUntilRedWarnings);

        // start red warning output
        logOutput.redWarnings = true;
    }

    public void EndScenario()
    {
        logOutput.EndOutput();

        // calculate and show score and feedback

        // present menu to quit or restart scenario
    }
}
