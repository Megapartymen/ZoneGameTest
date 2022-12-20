using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

[RequireComponent(typeof(ItemStateHandler))]
public class Item : MonoBehaviour
{
    [SerializeField] private Vector3 _inPocketSize;
    private Rigidbody _rigidbody;
    private ItemStateHandler _itemStateHandler;

    public string Name;
    public XRDirectInteractor CurrentDirectInteractor;
    public XRGrabInteractable GrabInteractable;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
}
