using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;

public class PocketInstruments : Pocket
{
    private List<InstrumentItem> _weaponsInPocket;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InstrumentItem item))
        {
            _currentItem = item;
            _vacuumEffect.transform.parent.GetComponent<LookAtScript>().Target = item.transform;
            _vacuumEffect.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out InstrumentItem item))
        {
            _vacuumEffect.transform.parent.GetComponent<LookAtScript>().Target = null;
            _vacuumEffect.Stop();
        }
    }
}
