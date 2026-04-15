using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public bool scenarioStarted;
    [SerializeField] float startTime;
    [SerializeField] float endTime;

    [SerializeField] List<Task> tasksCorrect;
    [SerializeField] List<Task> tasksPerformed = new List<Task>();

    [SerializeField] int secondsUntilYellowWarnings;
    [SerializeField] int secondsUntilRedWarnings;

    [SerializeField] LogOutput logOutput;
    [SerializeField] GameObject startScreen;

    [SerializeField] ResultsManager resultsManager;

    [SerializeField] Task userWarningsTask;
    [SerializeField] Task systemWarningsTask;
    [SerializeField] Task databaseWarningsTask;

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

    public void AddPerformedTask(Task task)
    {
        tasksPerformed.Add(task);
    }

    public void StartScenario()
    {
        if (scenarioStarted)
        {
            return;
        }

        StartCoroutine("Scenario");

        scenarioStarted = true;
        startTime = Time.time;
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
        userWarningsTask.CompleteTask();

        yield return new WaitForSeconds(secondsUntilRedWarnings);

        // start red warning output
        logOutput.yellowWarnings = false;
        logOutput.databaseWarnings = true;
        systemWarningsTask.CompleteTask();
        logOutput.redWarnings = true;
        databaseWarningsTask.CompleteTask();
    }

    public void EndScenario()
    {
        endTime = Time.time;

        logOutput.EndOutput();

        // calculate and show score and feedback
        if (tasksPerformed[0].taskID == 30) // remove first if standard
        {
            tasksPerformed.RemoveAt(0);
        }
        //resultsManager.CreateMenu(scenarioExecutionFlowCorrect.ToArray(), scenarioExecutionFlowCorrectPoints.ToArray(), scenarioExecutionFlowPerformed.ToArray(), scenarioExecutionFlowPerformedPoints.ToArray(), feedbackComments.ToArray());
        resultsManager.CreateMenu(tasksCorrect.ToArray(), tasksPerformed.ToArray(), endTime - startTime);

        // present menu to quit or restart scenario
    }
}
