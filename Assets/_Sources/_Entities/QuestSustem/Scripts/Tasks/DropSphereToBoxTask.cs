using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSphereToBoxTask : QuestTask
{
    [SerializeField] private TriggerBox triggerBox;
    [SerializeField] private Item _item;

    private QuestSystem _questSystem;

    private void Awake()
    {
        _questSystem = FindObjectOfType<QuestSystem>();
    }

    private void OnEnable()
    {
        triggerBox.OnInBoxDropped += CheckItemInBox;
    }

    private void OnDisable()
    {
        triggerBox.OnInBoxDropped += CheckItemInBox;
    }

    private void CheckItemInBox(Item item)
    {
        if (item.Name == _item.Name)
        {
            OnTaskCompleted?.Invoke(this);
            Debug.Log("[QUEST SYSTEM] Task completed");
        }
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
