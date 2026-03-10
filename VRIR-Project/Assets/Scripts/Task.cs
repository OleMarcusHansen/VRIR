using UnityEngine;

public class Task : MonoBehaviour
{
    public string taskName;
    public bool completed;
    public bool repeatable;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CompleteTask()
    {
        if (completed && !repeatable)
        {
            return;
        }

        completed = true;
        ScenarioManager.instance.scenarioExecutionFlowPerformed.Add(taskName);
    }
}
