using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{

    
    #region Events

    public delegate void StartTouch(Vector2 position, float time);

    public event StartTouch OnStartTouch;
    
    public delegate void EndTouch(Vector2 position, float time);

    public event EndTouch OnEndTouch;
    
    public delegate void Tap(Vector2 position);

    public event Tap OnTap;
    
    public delegate void StartHold(Vector2 position);

    public event StartHold OnStartHold;
    
    public delegate void EndHold(Vector2 position);

    public event EndHold OnEndHold;
    
    #endregion
    
    
    private BaseInputActionMap playerControls;
    private Camera mainCam;
    
    private void Awake()
    {
        playerControls = new BaseInputActionMap();
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the event and pass the context of the event to the function and call it
        playerControls.PlayerActions.PrimaryContact.started += StartTouchPrimary;
        playerControls.PlayerActions.PrimaryContact.canceled += EndTouchPrimary;

        playerControls.PlayerActions.PrimaryTap.performed += TapPrimary;
        
        playerControls.PlayerActions.PrimaryHold.performed += StartHoldPrimary;
        playerControls.PlayerActions.PrimaryHold.canceled += EndHoldPrimary;
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(Utils.ScreenToWorld(mainCam, playerControls.PlayerActions.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(Utils.ScreenToWorld(mainCam, playerControls.PlayerActions.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    private void TapPrimary(InputAction.CallbackContext context)
    {
        OnTap?.Invoke(Utils.ScreenToWorld(mainCam, playerControls.PlayerActions.PrimaryPosition.ReadValue<Vector2>()));
    }
    
    private void StartHoldPrimary(InputAction.CallbackContext context)
    {
        OnStartHold?.Invoke(Utils.ScreenToWorld(mainCam, playerControls.PlayerActions.PrimaryPosition.ReadValue<Vector2>()));
    }

    private void EndHoldPrimary(InputAction.CallbackContext context)
    {
        OnEndHold?.Invoke(Utils.ScreenToWorld(mainCam, playerControls.PlayerActions.PrimaryPosition.ReadValue<Vector2>()));
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCam, playerControls.PlayerActions.PrimaryPosition.ReadValue<Vector2>());
    }

    public Ray GetScreenToWorldRay()
    {
        return Utils.ScreenToRay(mainCam, playerControls.PlayerActions.PrimaryPosition.ReadValue<Vector2>());
    }
}
