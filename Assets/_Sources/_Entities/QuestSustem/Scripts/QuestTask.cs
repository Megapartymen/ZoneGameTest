using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestTask : MonoBehaviour
{
    public string TaskName;
    public bool IsCompleted;
    public bool IsCycled;
    public TaskAward[] Award;
    
    public Action<QuestTask> OnTaskCompleted;

    public abstract void ActionTaskStart();
    public abstract void ActionTaskEnd();
}
