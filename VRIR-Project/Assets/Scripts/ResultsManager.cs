using System.Linq;
using UnityEngine;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] Transform correctTasksParent;
    [SerializeField] Transform performedTasksParent;
    [SerializeField] Transform feedbackParent;

    [SerializeField] GameObject resultTaskPrefab;

    [SerializeField] Color positive;
    [SerializeField] Color negative;

    int score = 0;

    public void CreateMenu(string[] correctTasks, string[] performedTasks)
    {
        AddTasks(correctTasks, correctTasksParent);
        AddTasks(performedTasks, performedTasksParent);
    }

    void AddTasks(string[] tasks, Transform parent)
    {
        foreach (string task in tasks)
        {
            ResultTask resultTask = Instantiate(resultTaskPrefab, parent).GetComponent<ResultTask>();
            resultTask.Setup(task, positive);
        }
    }
    void EvaluateTasks(string[] correctTasks, string[] performedTasks)
    {
        for (int i = 0; i < performedTasks.Length; i++)
        {
            // add score for every performed task that exists in correct tasks
            // check conditions and make red, give comment, and subtract score
        }
    }
}
