using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    private QuestTask[] _questTasks;

    private void Awake()
    {
        _questTasks = FindObjectsOfType<QuestTask>();
    }

    private void Start()
    {
        PrepareTasks();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _questTasks.Length; i++)
        {
            _questTasks[i].OnTaskCompleted += InitEndOfTask;
        }
    }
    
    private void OnDisable()
    {
        for (int i = 0; i < _questTasks.Length; i++)
        {
            _questTasks[i].OnTaskCompleted -= InitEndOfTask;
        }
    }

    private void InitEndOfTask(QuestTask task)
    {
        task.ActionTaskEnd();
    }

    private void PrepareTasks()
    {
        for (int i = 0; i < _questTasks.Length; i++)
        {
            _questTasks[i].ActionTaskStart();
        }
    }
}
