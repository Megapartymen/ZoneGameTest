using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableLogic : MonoBehaviour
{
    [HideInInspector] public ActionBasedController Controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ActionBasedController controller))
        {
            Controller = controller;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ActionBasedController controller))
        {
            Controller = null;
        }
    }
}
