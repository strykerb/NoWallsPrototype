using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    EnvironmentManager environment;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake()
    {
        // Find environment in scene
        environment = FindObjectOfType<EnvironmentManager>();

        // Initialize and setup the Input System
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        // Send event to Movement.cs when jump input is detected
        // _ is a throw-away variable since there's no direction/strength of jump
        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.WallShift.performed += _ => mouseLook.ShiftGaze(movement.isGrounded);
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

    }

    void Update()
    {
        movement.recieveInput(horizontalInput);
        mouseLook.RecieveInput(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        controls.Disable();
        Cursor.lockState = CursorLockMode.None;
    }
}
