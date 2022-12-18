using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;
    public Collider CurrentTridderCollider;

    private void OnTriggerEnter(Collider other)
    {
        CurrentTridderCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentTridderCollider = null;
    }
}
