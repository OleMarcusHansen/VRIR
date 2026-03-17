using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    public string taskName;
    public bool completed;
    public bool repeatable;

    public UnityEvent onTaskPerformed;

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
        onTaskPerformed.Invoke();
        ScenarioManager.instance.AddPerformedTask(taskName);
    }
}
