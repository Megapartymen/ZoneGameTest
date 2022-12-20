using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private bool _isRight;
    [SerializeField] private float _speedRotation;
    
    private void Update()
    {
        if (_isRight)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x, 
                transform.localRotation.eulerAngles.y,transform.localRotation.eulerAngles.z + _speedRotation));
        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x, 
                transform.localRotation.eulerAngles.y,transform.localRotation.eulerAngles.z - _speedRotation));
        }
    }
}
