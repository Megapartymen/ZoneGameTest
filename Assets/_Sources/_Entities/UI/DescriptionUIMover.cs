using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionUIMover : MonoBehaviour
{
    [SerializeField] private Transform _master;

    private void Update()
    {
        transform.position = _master.position;
    }
}
