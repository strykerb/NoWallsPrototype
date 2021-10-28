using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    Vector2 horizontalInput;

    private void Awake()
    {
        // Initialize and setup the Input System
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
    }

    void Update()
    {
        movement.recieveInput(horizontalInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
