using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Collider _bottomCollider;
    [SerializeField] private Collider _volumeCollider;
    
    public Action<Item> OnInBoxDropped;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
            OnInBoxDropped?.Invoke(item);
    }
}
