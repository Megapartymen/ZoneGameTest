using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        if (Target == null)
            transform.LookAt(Camera.main.transform);
        else
            transform.LookAt(Target);
    }
}
