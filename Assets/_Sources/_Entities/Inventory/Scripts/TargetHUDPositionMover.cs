using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHUDPositionMover : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    
    public Vector3 Correction;
    
    private void Update()
    {
        transform.position = _parent.position + Correction;
    }
}
