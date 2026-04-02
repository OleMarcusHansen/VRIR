using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    public int taskID;
    public int[] prerequisites;
    public string taskName;
    public string taskFailureFeedback;
    public bool completed;
    public bool repeatable;

    public UnityEvent onTaskPerformed;

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
