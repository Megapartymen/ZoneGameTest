using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum HandState
{
    Idle,
    Hover,
    ReadyToGrab,
    ReadyToPress,
    Grab
}

public class HandController : MonoBehaviour
{
    [SerializeField] private ActionBasedController _controller;
    [SerializeField] private Animator _animator;
    
    private VRInputSystem _vrInputSystem;

    public HandState HandState;

    public bool IsReadyToGrab;
    public bool Grab;

    private void Awake()
    {
        _vrInputSystem = FindObjectOfType<VRInputSystem>();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (_controller == _vrInputSystem.LeftController)
        {
            _animator.SetFloat("Grip", _vrInputSystem.CurrentLeftGripValue);
        }
        else if (_controller == _vrInputSystem.RightController)
        {
            _animator.SetFloat("Grip", _vrInputSystem.CurrentRightGripValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out XRGrabInteractable interactable))
        {
            IsReadyToGrab = true;
            _animator.SetBool("Hover", true);
            _controller = interactable.GetComponent<InteractableLogic>().Controller;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out XRGrabInteractable interactable))
        {
            IsReadyToGrab = false;
            _animator.SetBool("Hover", false);
            _controller = null;
        }
    }
}
