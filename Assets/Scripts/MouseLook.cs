using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    EnvironmentManager environment;
    [SerializeField] float sensitivityX;
    [SerializeField] float sensitivityY;
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    [SerializeField] float zCorrectionSpeed = 1;

    float mouseX, mouseY;
    float xRotation = 0f;
    float zRotation = 0f;

    Vector3 RotationMask;

    public void RecieveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    // Update is called once per frame
    void Update()
    {
        // Get current rotation
        Vector3 targetRotation = transform.eulerAngles; //transform.eulerAngles;

        // Handle X rotation (rotates player)
        targetRotation += RotationMask * mouseX;
        transform.eulerAngles = targetRotation;

        // Handle Y rotation (rotates camera)
        xRotation -= mouseY;
        // Clamp camera rotation
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        
        targetRotation.z = zRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    private void Start()
    {
        RotationMask = new Vector3(0f, 1f, 0f);
        environment = FindObjectOfType<EnvironmentManager>();
    }

    public void ShiftGaze(bool grounded)
    {
        // Don't shift environment if player is looking down or is mid-air
        if (!grounded || playerCamera.eulerAngles.x <= 0)
        {
            return;
        }
        xRotation += 90;
        
        float rot = transform.eulerAngles.y;
        Vector3 targetPosition = Vector3.zero;
        if (rot >= 45f && rot < 135f)
        {
            Debug.Log("Case B");
            targetPosition = new Vector3(transform.position.y, -transform.position.x, transform.position.z);
            //newRotation = new Vector3(-transform.eulerAngles.x, 0f, -90f);
            environment.Shift(new Vector3(0f, 0f, -90f));
            zRotation = -(90 - transform.eulerAngles.y);
        }
        else if (rot >= 135f && rot < 225f)
        {
            Debug.Log("Case C");
            targetPosition = new Vector3(transform.position.x, transform.position.z, -transform.position.y);
            //newRotation = new Vector3(-90f, 0f, -transform.eulerAngles.z);
            environment.Shift(new Vector3(-90f, 0f, 0f));
            zRotation = -(180 - transform.eulerAngles.y);
        }
        else if (rot >= 225f && rot < 315f)
        {
            Debug.Log("Case D");
            targetPosition = new Vector3(-transform.position.y, transform.position.x, transform.position.z);
            //newRotation = new Vector3(-transform.eulerAngles.x, 0f, 90f);
            environment.Shift(new Vector3(0f, 0f, 90f));
            zRotation = -(270-transform.eulerAngles.y);
        }
        else
        {
            Debug.Log("Case A");
            targetPosition = new Vector3(transform.position.x, -transform.position.z, transform.position.y);
            //newRotation = new Vector3(90f, 0f, -transform.eulerAngles.z);
            environment.Shift(new Vector3(90f, 0f, 0f));
            zRotation = transform.eulerAngles.y;
        }
        transform.position = targetPosition;
        StartCoroutine("CorrectZRotation");
    }

    IEnumerator CorrectZRotation()
    {
        do
        {
            yield return new WaitForSeconds(0.01f);
            zRotation = Mathf.LerpAngle(zRotation, 0f, zCorrectionSpeed);
        } while (zRotation != 0);
        yield return true;
    }
}
