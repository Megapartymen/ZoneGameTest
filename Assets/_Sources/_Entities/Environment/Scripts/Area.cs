using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public Action OnPlayerInArea;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController characterController))
        {
            OnPlayerInArea?.Invoke();
        }
    }
}
