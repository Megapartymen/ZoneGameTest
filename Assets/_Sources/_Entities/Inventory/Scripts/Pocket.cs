using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pocket : MonoBehaviour
{
    [SerializeField] protected Transform _crystalPocket;
    [SerializeField] protected Transform _pocketHUD;
    [SerializeField] protected TargetHUDPositionMover _targetPocketHUDposition;
    [SerializeField] protected InventoryCrystal _inventoryCrystal;
    [SerializeField] protected ParticleSystem _vacuumEffect;

    [Space] [Header("Item sockets")]
    [SerializeField] protected Transform _firstSocket;
    [SerializeField] protected Transform _secondtSocket;
    [SerializeField] protected Transform _thirdSocket;

    protected Vector3 _openCorrection;
    protected Vector3 _closedCorrection;
    protected Vector3 _closedScale;
    protected Vector3 _openScale;
    
    protected InventorySystem _inventorySystem;
    protected VRInputSystem _vrInputSystem;
    protected Item _currentItem;
    
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
    
    private void Start()
    {
        _pocketHUD.localScale = Vector3.zero;
    }
    
    private void Update()
    {
        _pocketHUD.position = Vector3.Lerp(_pocketHUD.position, _targetPocketHUDposition.transform.position, 5 * Time.deltaTime);
        _pocketHUD.LookAt(Camera.main.transform.position);
    }

    private void LateUpdate()
    {
        CheckItemIsNear();
    }

    private void OnEnable()
    {
        _inventoryCrystal.OnCrystalTouched += SwitchPocket;
    }

    private void OnDisable()
    {
        _inventoryCrystal.OnCrystalTouched -= SwitchPocket;
    }

    public Transform GetSocket()
    {
        return _firstSocket;
    }
    
    public void ClosePocketAfterGrab()
    {
        ClosePocket();
    }
    
    private void SwitchPocket()
    {
        if (_inventorySystem.IsPocketCanOpen)
        {
            OpenPocket();
        }
        else if (IsOpen)
        {
            ClosePocket();
        }
    }

    private void OpenPocket()
    {
        OnPocketOpen?.Invoke();
        IsOpen = true;
        _vrInputSystem.SendHapticImpulse(0.2f, 0.05f, VRController.Left);
        _inventoryCrystal.CrystalShine.Play();
        _targetPocketHUDposition.Correction = _openCorrection;
        _pocketHUD.DOScale(_openScale, 0.5f);
    }

    private void ClosePocket()
    {
        OnPocketClosed?.Invoke();
        IsOpen = false;
        _vrInputSystem.SendHapticImpulse(0.2f, 0.05f, VRController.Left);
        _inventoryCrystal.CrystalShine.Stop();
        _targetPocketHUDposition.Correction = _closedCorrection;
        _pocketHUD.DOScale(_closedScale, 0.5f);
    }

    private void CheckItemIsNear()
    {
        Debug.Log("CHECK ITEM");
        
        if (_currentItem == null)
            return;
        
        Debug.Log("HAVE CURRENT ITEM");
        
        if (!_currentItem.GetNearPocketStatus())
        {
            Debug.Log("STOP EFFECT");
            
            _vacuumEffect.Stop();
            _currentItem = null;
        }
    }
}
