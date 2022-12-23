using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

[RequireComponent(typeof(ItemStateHandler))]
public class Item : MonoBehaviour
{
    protected ItemStateHandler _itemStateHandler;

    public string Name;
    public XRDirectInteractor CurrentDirectInteractor;
    public XRGrabInteractable GrabInteractable;

    private void Awake()
    {
        GrabInteractable = GetComponent<XRGrabInteractable>();
        _itemStateHandler = GetComponent<ItemStateHandler>();
    }

    private void Update()
    {
        TryToMoveFromParent();
    }

    private void TryToMoveFromParent()
    {
        if (_itemStateHandler.PocketParent != null)
        {
            transform.position = _itemStateHandler.PocketParent.position;
        }
    }

    public bool GetNearPocketStatus()
    {
        return _itemStateHandler.ItemPocketState == ItemPocketState.NearPocket;
    }
}
