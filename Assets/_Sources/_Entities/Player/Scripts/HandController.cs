using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    [SerializeField] private ActionBasedController _controller;
    [SerializeField] private Animator _animator;
    
    private VRInputSystem _vrInputSystem;

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
        else
        {
            _animator.SetFloat("Grip", _vrInputSystem.CurrentRightGripValue);
        }
    }
}
