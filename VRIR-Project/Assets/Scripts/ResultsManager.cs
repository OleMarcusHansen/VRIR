using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] Transform correctTasksParent;
    [SerializeField] Transform performedTasksParent;
    [SerializeField] Transform feedbackParent;

    [SerializeField] GameObject resultTaskPrefab;
    [SerializeField] GameObject resultFeedbackPrefab;

    List<string> addedFeedback = new List<string>();

    [SerializeField] Color positive;
    [SerializeField] Color negative;
    [SerializeField] Color neutral;

    int score = 0;

    public void CreateMenu(Task[] correctTasks, Task[] performedTasks)
    {
        AddTasks(correctTasks, correctTasksParent);
        AddPerformedTasks(performedTasks, performedTasksParent);
    }

    void AddTasks(Task[] tasks, Transform parent)
    {
        foreach (Task task in tasks)
        {
            ResultTask resultTask = Instantiate(resultTaskPrefab, parent).GetComponent<ResultTask>();
            resultTask.Setup(task.taskName, positive);

            if (task.nonUserTask)
            {
                resultTask.SetColor(neutral);
            }
        }
    }
    void AddPerformedTasks(Task[] tasks, Transform parent)
    {
        List<int> IDs = new List<int>();

        foreach (Task task in tasks)
        {
            ResultTask resultTask = Instantiate(resultTaskPrefab, parent).GetComponent<ResultTask>();
            resultTask.Setup(task.taskName, positive);

            if (task.nonUserTask)
            {
                resultTask.SetColor(neutral);
            }
            foreach (int id in task.prerequisites)
            {
                if (!IDs.Contains(id))
                {
                    resultTask.SetColor(negative);

                    if (!addedFeedback.Contains(task.taskFailureFeedback))
                    {
                        ResultTask feedbackText = Instantiate(resultFeedbackPrefab, feedbackParent).GetComponent<ResultTask>();
                        feedbackText.Setup(task.taskFailureFeedback, negative);
                        addedFeedback.Add(task.taskFailureFeedback);
                    }
                }
            }

            IDs.Add(task.taskID);
        }
    }
}
