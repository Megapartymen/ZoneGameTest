using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableLogic : MonoBehaviour
{
    // private Transform _attachPoint;
    // private Transform _attachPointHand;
    // private XRGrabInteractable _grabInteractable;
    //
    // private bool _isBusy;
    //
    // [HideInInspector] public ActionBasedController Controller;
    //
    // private void Awake()
    // {
    //     _grabInteractable = GetComponent<XRGrabInteractable>();
    //     _attachPoint = _grabInteractable.attachTransform;
    // }
    //
    // private void Start()
    // {
    //     
    // }
    //
    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.TryGetComponent(out ActionBasedController controller))
    //     {
    //         if ((_attachPoint.position - /*controller.GetComponent<XRGrabInteractable>().attachTransform.position*/_attachPointHand.position).magnitude < 0.03)
    //         {
    //             Controller = controller;
    //         }
    //     }
    // }
    //
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.TryGetComponent(out ActionBasedController controller))
    //     {
    //         _attachPointHand = controller.GetComponent<XRDirectInteractor>().attachTransform;
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.TryGetComponent(out ActionBasedController controller))
    //     {
    //         Controller = null;
    //     }
    // }
}
