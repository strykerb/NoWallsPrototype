using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] float gravityStrength;
    [SerializeField] LayerMask groundMask;
    
    Vector2 horizontalInput;
    Vector3 verticalVelocity = Vector3.zero;

    bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks for collision with ground, resets vertical velocity
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded) { verticalVelocity.y = 0; }

        // Convert WASD Vector2 input into a movement Vector3 in 3d space
        Vector3 horizontalVelocity = speed * (transform.right * horizontalInput.x + transform.forward * horizontalInput.y);
        controller.Move(horizontalVelocity * Time.deltaTime);

        // Apply gravity to player
        // s0 = v0t + ½at^2
        verticalVelocity.y -= gravityStrength * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
       
        
    }

    public void recieveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }
}
