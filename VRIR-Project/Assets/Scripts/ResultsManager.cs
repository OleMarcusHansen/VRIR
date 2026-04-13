using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] Transform correctTasksParent;
    [SerializeField] Transform performedTasksParent;
    [SerializeField] Transform feedbackParent;

    [SerializeField] GameObject resultTaskPrefab;
    [SerializeField] GameObject resultFeedbackPrefab;

    [SerializeField] Color positive;
    [SerializeField] Color negative;
    [SerializeField] Color neutral;

    int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;

    public void CreateMenu(Task[] correctTasks, Task[] performedTasks, float playTime)
    {
        AddTasks(correctTasks, correctTasksParent);
        AddPerformedTasks(correctTasks, performedTasks, performedTasksParent);

        TimeSpan timeSpan = TimeSpan.FromSeconds(playTime);
        timeText.text = string.Format("Time: {0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
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
    void AddPerformedTasks(Task[] correctTasks, Task[] performedTasks, Transform parent)
    {
        List<int> IDs = new List<int>();
        List<int> IDPoints = new List<int>();
        List<string> addedFeedback = new List<string>();

        foreach (Task task in performedTasks)
        {
            ResultTask resultTask = Instantiate(resultTaskPrefab, parent).GetComponent<ResultTask>();
            resultTask.Setup(task.taskName, positive);

            bool getPoint = true;

            if (task.nonUserTask)
            {
                resultTask.SetColor(neutral);
                getPoint = false;
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

                    getPoint = false;
                }
            }
            if (!CheckIfCorrect(task.taskID, correctTasks))
            {
                resultTask.SetColor(negative);

                if (task.taskFailureFeedback != string.Empty && !addedFeedback.Contains(task.taskFailureFeedback))
                {
                    ResultTask feedbackText = Instantiate(resultFeedbackPrefab, feedbackParent).GetComponent<ResultTask>();
                    feedbackText.Setup(task.taskFailureFeedback, negative);
                    addedFeedback.Add(task.taskFailureFeedback);
                }

                getPoint = false;
            }
            if (IDPoints.Contains(task.taskID))
            {
                getPoint = false;
            }
            if (getPoint)
            {
                score++;
                IDPoints.Add(task.taskID);
            }

            IDs.Add(task.taskID);
        }

        scoreText.text = "Score: " + score + " / " + MaxScore(correctTasks);
    }

    int MaxScore(Task[] correctTasks)
    {
        int m = 0;
        foreach (Task task in correctTasks)
        {
            if (!task.nonUserTask)
            {
                m++;
            }
        }
        return m;
    }

    bool CheckIfCorrect(int taskID, Task[] correctTasks)
    {
        foreach (Task task in correctTasks)
        {
            if (task.taskID == taskID)
            {
                return true;
            }
        }

        return false;
    }
}
