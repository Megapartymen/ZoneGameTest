using System;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public Action<Item> OnInBoxDropped;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
            OnInBoxDropped?.Invoke(item);
    }
}
