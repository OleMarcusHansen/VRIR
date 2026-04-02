using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public bool scenarioStarted;

    [SerializeField] List<string> scenarioExecutionFlowCorrect;
    [SerializeField] List<bool> scenarioExecutionFlowCorrectPoints;
    [SerializeField] List<string> scenarioExecutionFlowPerformed = new List<string>();
    [SerializeField] List<bool> scenarioExecutionFlowPerformedPoints = new List<bool>();

    [SerializeField] List<string> feedbackComments;

    [SerializeField] List<Task> tasksCorrect;
    [SerializeField] List<Task> tasksPerformed = new List<Task>();

    [SerializeField] int secondsUntilYellowWarnings;
    [SerializeField] int secondsUntilRedWarnings;

    [SerializeField] LogOutput logOutput;
    [SerializeField] GameObject startScreen;

    [SerializeField] ResultsManager resultsManager;

    [SerializeField] int score = 0;

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

    public void AddPerformedTask(string taskName)
    {
        if (scenarioExecutionFlowCorrect.Contains(taskName))
        {
            scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = true;
            scenarioExecutionFlowPerformedPoints.Add(true);
        }
        else
        {
            scenarioExecutionFlowPerformedPoints.Add(false);
        }

        int i = scenarioExecutionFlowPerformedPoints.Count - 1;
        /*
        if (logOutput.yellowWarnings || logOutput.redWarnings || logOutput.databaseWarnings)
        {
            scenarioExecutionFlowPerformedPoints.Add(true);
            scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = true;
        }
        else
        {
            scenarioExecutionFlowPerformedPoints.Add(false);
            scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = false;
            feedbackComments.Add("Plan was performed preemptively, which can cause unecessary system or process disruptions");
        }*/

        if (taskName != "Notify Leaders" && taskName != "Read Incident Response Plan")
        {
            if (!scenarioExecutionFlowPerformed.Contains("Notify Leaders"))
            {
                if (!feedbackComments.Contains("Actions were performed before leaders were notified"))
                {
                    feedbackComments.Add("Actions were performed before leaders were notified");
                    scenarioExecutionFlowPerformedPoints[i] = false;
                    scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = false;
                }
            }
        }
        if (taskName == "Log Out All Users")
        {
            if (!scenarioExecutionFlowPerformed.Contains("Enforce Two-Factor Authentication"))
            {
                feedbackComments.Add("Users were logged out before 2FA was enforced, which may allow compromised user accounts to log back in");
                scenarioExecutionFlowPerformedPoints[i] = false;
                scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = false;
            }
            if (!scenarioExecutionFlowPerformed.Contains("Renew Passwords"))
            {
                feedbackComments.Add("Users were logged out before passwords were reset, which may allow compromised user accounts to log back in");
                scenarioExecutionFlowPerformedPoints[i] = false;
                scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = false;
            }
        }
        else if (taskName == "Run Malware Remover")
        {
            if (!scenarioExecutionFlowPerformed.Contains("Run System Analysis"))
            {
                feedbackComments.Add("Malware remover was ran before system analysis, which may minimize effect");
                scenarioExecutionFlowPerformedPoints[i] = false;
                scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = false;
            }
            if (!scenarioExecutionFlowPerformed.Contains("Save System State"))
            {
                feedbackComments.Add("Malware remover was ran before system state was saved, losing malware analysis and documentation capabilities");
                scenarioExecutionFlowPerformedPoints[i] = false;
                scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = false;
            }
        }
        else if (taskName == "Revert to Backup")
        {
            if (!scenarioExecutionFlowPerformed.Contains("Prepare Correct Backup Database"))
            {
                feedbackComments.Add("Database was reverted to a wrong backup, not containing the newest or correct data");
                scenarioExecutionFlowPerformedPoints[i] = false;
                scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = false;
            }
            if (!scenarioExecutionFlowPerformed.Contains("Save Log"))
            {
                feedbackComments.Add("Database was reverted before saving the log output, losing data for incident analysis and documentation");
                scenarioExecutionFlowPerformedPoints[i] = false;
                scenarioExecutionFlowCorrectPoints[scenarioExecutionFlowCorrect.IndexOf(taskName)] = false;
            }
        }

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
        //if (scenarioExecutionFlowPerformed[0] == "Insert Standard Config") // remove first if standard
        //{
        //    scenarioExecutionFlowPerformed.RemoveAt(0);
        //}
        resultsManager.CreateMenu(scenarioExecutionFlowCorrect.ToArray(), scenarioExecutionFlowCorrectPoints.ToArray(), scenarioExecutionFlowPerformed.ToArray(), scenarioExecutionFlowPerformedPoints.ToArray(), feedbackComments.ToArray());

        // present menu to quit or restart scenario
    }
}
