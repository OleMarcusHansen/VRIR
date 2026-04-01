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
    void EvaluateTasks(List<string> correctTasks, List<string> performedTasks)
    {
        // add score for every performed task that exists in correct tasks
        for (int i = 0; i < correctTasks.Count; i++)
        {
            if (performedTasks.Contains(correctTasks[i]))
            {
                score++;
            }
        }

        List<string> completed = new List<string>();

        // check conditions and make red, give comment, and subtract score
        for (int i = 0; i < performedTasks.Count; i++)
        {
            if (!correctTasks.Contains(performedTasks[i]))
            {
                resultTasks[i].SetColor(neutral);
            }
            
            completed.Add(correctTasks[i]);
        }
    }
}
