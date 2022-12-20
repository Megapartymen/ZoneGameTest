using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public enum ItemHandState
{
    Free,
    Hovered,
    InHand
}

public enum ItemPocketState
{
    OutPocket,
    NearPocket,
    InPocket
}

public class ItemStateHandler : MonoBehaviour
{
    private bool _isDropped;
    private bool _isBeTouched;
    private bool _isUncollapsed;
    private Collider _collider;
    private Vector3 _normalSize;

    public bool IsNearPocket;
    public Transform PocketParent;
    public Pocket CurrentPocket;
    public XRGrabInteractable GrabInteractable;
    public ItemHandState ItemHandSate;
    public ItemPocketState ItemPocketState;
    
    private void Awake()
    {
        GrabInteractable = GetComponent<XRGrabInteractable>();
        ItemHandSate = ItemHandState.Free;
        ItemPocketState = ItemPocketState.OutPocket;
        _collider = GetComponent<Collider>();
    }
    
    private void Start()
    {
        _normalSize = transform.localScale;
        _isUncollapsed = true;
    }

    private void Update()
    {
        TryGetParent();
        SetDroppedStatus();
        SetHandState();
        SetPocketSate();
        CheckCollapsedState();
    }
    
    
    private void SetHandState()
    {
        if (GrabInteractable.interactorsHovering.Count == 0
            && GrabInteractable.interactorsSelecting.Count == 0)
        {
            ItemHandSate = ItemHandState.Free;
        }
        else if (GrabInteractable.interactorsHovering.Count > 0 && GrabInteractable.interactorsSelecting.Count == 0)
        {
            ItemHandSate = ItemHandState.Hovered;
        }
        else if (GrabInteractable.interactorsSelecting.Count > 0)
        {
            ItemHandSate = ItemHandState.InHand;
        }
    }

    private void SetPocketSate()
    {
        if (!IsNearPocket && PocketParent == null)
        {
            ItemPocketState = ItemPocketState.OutPocket;
        }
        else if (IsNearPocket && ItemHandSate == ItemHandState.InHand )
        {
            ItemPocketState = ItemPocketState.NearPocket;
        }
        else if (PocketParent != null)
        {
            ItemPocketState = ItemPocketState.InPocket;
        }
    }

    private void SetDroppedStatus()
    {
        if (ItemHandSate == ItemHandState.InHand)
        {
            _isBeTouched = true;
        }

        if (ItemHandSate == ItemHandState.Hovered && _isBeTouched)
        {
            _isDropped = true;
        }

        if (ItemHandSate == ItemHandState.Free)
        {
            _isBeTouched = false;
            _isDropped = false;
        }
    }

    private void TryGetParent()
    {
        if (IsNearPocket && _isDropped && CurrentPocket != null)
        {
            PocketParent = CurrentPocket.GetSocket();

            if (!CurrentPocket.IsOpen)
            {
                SetCollapsed();
            }
        }

        if (ItemHandSate == ItemHandState.InHand)
        {
            PocketParent = null;
            
            if (CurrentPocket != null)
                CurrentPocket.ClosePocketAfterGrab();
            
            CurrentPocket = null;
        }
    }

    private void CheckCollapsedState()
    {
        if (CurrentPocket == null || CurrentPocket.IsOpen == _isUncollapsed)
            return;
        
        if (CurrentPocket.IsOpen)
            SetUncollapsed();
        else
            SetCollapsed();
    }

    private void SetCollapsed()
    {
        Sequence toCollaps = DOTween.Sequence();
        toCollaps.AppendCallback(() => _collider.enabled = false)
            .Append(transform.DOScale(Vector3.zero, 0.3f));
        _isUncollapsed = false;
    }

    private void SetUncollapsed()
    {
        Sequence toUncollaps = DOTween.Sequence();
        toUncollaps.AppendCallback(() => _collider.enabled = true)
            .Append(transform.DOScale(_normalSize, 0.3f));
        _isUncollapsed = true;
    }
}
