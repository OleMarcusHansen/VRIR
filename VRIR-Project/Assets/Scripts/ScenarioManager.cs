using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public bool ScenarioStarted;

    [SerializeField] string[] scenarioExecutionFlowCorrect;
    public List<string> scenarioExecutionFlowPerformed = new List<string>();

    [SerializeField] int secondsUntilYellowWarnings;
    [SerializeField] int secondsUntilRedWarnings;

    public static ScenarioManager instance;
    void Start()
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

    IEnumerator StartScenario()
    {
        if (ScenarioStarted)
        {
            yield break;
        }

        // start normal log output

        yield return secondsUntilYellowWarnings;

        // start yellow warning output

        yield return secondsUntilRedWarnings;

        // start red warning output
    }

    public void EndScenario()
    {
        // stop enumerator

        // calculate and show score and feedback

        // present menu to quit or restart scenario
    }
}
