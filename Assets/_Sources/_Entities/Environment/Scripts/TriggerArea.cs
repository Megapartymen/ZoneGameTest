using System;
using UnityEngine;

public class TriggerArea : MonoBehaviour
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
