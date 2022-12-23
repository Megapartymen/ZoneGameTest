using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToAreaTask : QuestTask
{
    [SerializeField] private TriggerArea triggerArea;
    
    private QuestSystem _questSystem;

    private void Awake()
    {
        _questSystem = FindObjectOfType<QuestSystem>();
    }

    private void OnEnable()
    {
        triggerArea.OnPlayerInArea += ActionTaskEnd;
    }

    private void OnDisable()
    {
        triggerArea.OnPlayerInArea += ActionTaskEnd;
    }


    public override void ActionTaskStart()
    {
        IsCompleted = false;
    }

    public override void ActionTaskEnd()
    {
        if (!IsCompleted)
        {
            for (int i = 0; i < Award.Length; i++)
            {
                Award[i].GetAward();
            }
        
            if (!IsCycled)
                IsCompleted = true;
        }
    }
}
