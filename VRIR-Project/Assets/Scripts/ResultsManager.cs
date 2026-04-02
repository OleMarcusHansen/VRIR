using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] Transform correctTasksParent;
    [SerializeField] Transform performedTasksParent;
    [SerializeField] Transform feedbackParent;

    [SerializeField] GameObject resultTaskPrefab;
    [SerializeField] ResultTask[] resultTasks;

    [SerializeField] Color positive;
    [SerializeField] Color negative;
    [SerializeField] Color neutral;

    int score = 0;

    public void CreateMenu(string[] correctTasks, bool[] correctPoints, string[] performedTasks, bool[] performedPoints, string[] feedback)
    {
        AddTasks(correctTasks, correctPoints, correctTasksParent);
        AddTasks(performedTasks, performedPoints, performedTasksParent);
        resultTasks = performedTasksParent.GetComponentsInChildren<ResultTask>();

    }

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
                }
            }

            IDs.Add(task.taskID);
        }
    }

    void AddTasks(string[] tasks, bool[] points, Transform parent)
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            ResultTask resultTask = Instantiate(resultTaskPrefab, parent).GetComponent<ResultTask>();
            if (points[i])
            {
                resultTask.Setup(tasks[i], positive);
            }
            else
            {
                resultTask.Setup(tasks[i], negative);
            }
        }
    }
}
