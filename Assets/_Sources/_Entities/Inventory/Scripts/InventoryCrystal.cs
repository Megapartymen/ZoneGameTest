using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCrystal : MonoBehaviour
{
    public ParticleSystem CrystalShine;
    
    public Action OnCrystalTouched;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IndexFingerMarker indexFingerMarker))
        {
            OnCrystalTouched?.Invoke();
        }
    }
}
