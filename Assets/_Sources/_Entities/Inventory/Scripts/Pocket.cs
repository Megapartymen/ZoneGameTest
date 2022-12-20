using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    [SerializeField] protected Transform _crystalPocket;
    [SerializeField] protected Transform _pocketHUD;
    [SerializeField] protected TargetHUDPositionMover _targetPocketHUDposition;
    [SerializeField] protected InventoryCrystal _inventoryCrystal;
    [SerializeField] protected ParticleSystem _vacuumEffect;

    [Space] [Header("Item sockets")]
    public Transform FirstSocket; // TODO: create getter
    [SerializeField] protected Transform _secondtSocket;
    [SerializeField] protected Transform _thirdSocket;

    protected Vector3 _openCorrection;
    protected Vector3 _closedCorrection;
    protected Vector3 _closedScale;
    protected Vector3 _openScale;
    
    protected InventorySystem _inventorySystem;
    protected VRInputSystem _vrInputSystem;
    public bool IsOpen;
    
    public Action OnPocketOpen;
    public Action OnPocketClosed;
    
    private void Awake()
    {
        _inventorySystem = FindObjectOfType<InventorySystem>();
        _vrInputSystem = FindObjectOfType<VRInputSystem>();
        _closedCorrection = Vector3.zero;
        _openCorrection = new Vector3(0,0.25f,0);
        _closedScale = Vector3.zero;
        _openScale = new Vector3(1, 1, 1);
    }
}
