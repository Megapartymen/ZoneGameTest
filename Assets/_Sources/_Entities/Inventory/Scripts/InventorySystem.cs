using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Pocket[] _pockets;

    public bool IsPocketCanOpen;

    private void Awake()
    {
        _pockets = FindObjectsOfType<Pocket>();
    }

    private void Start()
    {
        IsPocketCanOpen = true;
    }

    private void OnEnable()
    {
        for (int i = 0; i < _pockets.Length; i++)
        {
            _pockets[i].OnPocketOpen += BindOpenPocketStatus;
            _pockets[i].OnPocketClosed += ClearOpenPocketStatus;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _pockets.Length; i++)
        {
            _pockets[i].OnPocketOpen -= BindOpenPocketStatus;
            _pockets[i].OnPocketClosed -= ClearOpenPocketStatus;
        }
    }

    private void BindOpenPocketStatus()
    {
        IsPocketCanOpen = false;
    }

    private void ClearOpenPocketStatus()
    {
        IsPocketCanOpen = true;
    }
}
