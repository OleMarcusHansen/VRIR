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
        completed = true;
        ScenarioManager.instance.scenarioExecutionFlowPerformed.Add(taskName);
    }
}
