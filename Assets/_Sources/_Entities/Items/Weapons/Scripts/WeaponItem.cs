using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PocketWeapons pocket))
        {
            _itemStateHandler.IsNearPocket = true;
            _itemStateHandler.CurrentPocket = pocket;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PocketWeapons pocket))
        {
            _itemStateHandler.IsNearPocket = false;
        }
    }
}
