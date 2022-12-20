using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;

// [RequireComponent(typeof(Pocket))]
public class PocketWeapons : Pocket
{
    private List<Weapon> _weaponsInPocket;
    
    private void Start()
    {
        _pocketHUD.localScale = Vector3.zero;
    }

    private void Update()
    {
        _pocketHUD.position = Vector3.Lerp(_pocketHUD.position, _targetPocketHUDposition.transform.position, 5 * Time.deltaTime);
        _pocketHUD.LookAt(Camera.main.transform.position);
    }

    private void OnEnable()
    {
        _inventoryCrystal.OnCrystalTouched += SwitchPocket;
    }

    private void OnDisable()
    {
        _inventoryCrystal.OnCrystalTouched -= SwitchPocket;
    }

    private void SwitchPocket()
    {
        if (_inventorySystem.IsPocketCanOpen)
        {
            OpenPocket();
        }
        else if (IsOpen)
        {
            ClosePocket();
        }
    }

    private void OpenPocket()
    {
        OnPocketOpen?.Invoke();
        IsOpen = true;
        _targetPocketHUDposition.Correction = _openCorrection;
        _pocketHUD.DOScale(_openScale, 0.5f);
    }

    private void ClosePocket()
    {
        OnPocketClosed?.Invoke();
        IsOpen = false;
        _targetPocketHUDposition.Correction = _closedCorrection;
        _pocketHUD.DOScale(_closedScale, 0.5f);
    }
}
