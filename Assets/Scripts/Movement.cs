using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float speed;
    [SerializeField] float gravityStrength;
    [SerializeField] float jumpHeight = 3.5f;
    
    Vector3 horizontalInput;
    Vector3 horizontalVelocity = Vector3.zero;
    Vector3 verticalVelocity = Vector3.zero;

    public bool isGrounded;
    bool jump;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        // Convert WASD Vector2 input into a movement Vector3 in 3d space
        horizontalVelocity = speed * (transform.right * horizontalInput.x + transform.forward * horizontalInput.y);

        // Apply gravity to vertical velocity
        // s0 = v0t + ½at^2
        verticalVelocity.y -= gravityStrength * Time.deltaTime;

        // checks for collision with ground, resets vertical velocity
        isGrounded = Physics.CheckSphere(transform.position - Vector3.up/2, 0.1f, groundMask);
        if (isGrounded) { verticalVelocity.y = 0; }

        // Set jump velocity if jump is detected
        if (jump)
        {
            if (isGrounded)
            {
                // Modify vertical velocity so that the player's position reaches jumpHeight
                body.AddRelativeForce(new Vector3(0, Mathf.Sqrt(2 * jumpHeight * gravityStrength), 0), ForceMode.Impulse);
                Debug.Log("jump.");
            }
            jump = false;
        }

        // Apply movement
        ApplyVelocities();
        
    }

    void ApplyVelocities()
    {
        Vector3 moveVector = transform.TransformDirection(horizontalInput) * speed;
        body.velocity = new Vector3(moveVector.x, body.velocity.y, moveVector.z);
    }

    public void recieveInput(Vector2 _horizontalInput)
    {
        horizontalInput.x = _horizontalInput.x;
        horizontalInput.y = 0f;
        horizontalInput.z = _horizontalInput.y;
    }

    public void OnJumpPressed()
    {
        jump = true;
    }
}
