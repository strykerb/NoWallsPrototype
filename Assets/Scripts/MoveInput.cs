using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveInput : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float speed;

    Vector3 horizontalInput;
    Vector3 horizontalVelocity = Vector3.zero;
    Vector3 verticalVelocity = Vector3.zero;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    private void Awake() {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
    }

    private void OnEnable() {
        groundMovement.HorizontalMovement.performed += OnHorizontalInput;
        controls.Enable();
    }

    private void OnDisable() {
        groundMovement.HorizontalMovement.performed -= OnHorizontalInput;
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnHorizontalInput(InputAction.CallbackContext context)
    {
        Vector2 readValue = context.ReadValue<Vector2>();
        
    }

    
}
