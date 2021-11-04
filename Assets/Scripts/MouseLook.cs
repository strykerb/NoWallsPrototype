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

        Vector3 currEnvRot = environment.transform.eulerAngles;
        float rot = transform.eulerAngles.y + currEnvRot.y;
        
        Vector3 targetPosition = Vector3.zero;
        Vector3 newRotation = currEnvRot;
        if (rot >= 45f && rot < 135f)
        {
            Debug.Log("Case B");
            targetPosition = new Vector3(transform.position.y, -transform.position.x, transform.position.z);
            
            if (currEnvRot.x == 90)
            {
                Debug.Log("Edge Case");
                newRotation.x -= currEnvRot.x;
                newRotation.y -= currEnvRot.x;
                newRotation.z -= currEnvRot.x;
            } 
            else
            {
                newRotation.z -= 90f;
            }
            zRotation = -(90 - transform.eulerAngles.y);
        }
        else if (rot >= 135f && rot < 225f)
        {
            Debug.Log("Case C");
            targetPosition = new Vector3(transform.position.x, transform.position.z, -transform.position.y);
            
            if (currEnvRot.y == 180)
            {
                newRotation.x = 90;
            }
            else
            {
                newRotation.x -= 90;
            }
            zRotation = -(180 - transform.eulerAngles.y);
        }
        else if (rot >= 225f && rot < 315f)
        {
            Debug.Log("Case D");
            targetPosition = new Vector3(-transform.position.y, transform.position.x, transform.position.z);
            if (currEnvRot.x == 90)
            {
                Debug.Log("Edge Case");
                newRotation.y -= currEnvRot.x;
                newRotation.x -= currEnvRot.x;
            }
            else
            {
                newRotation.z += 90;
            }
            zRotation = -(270-transform.eulerAngles.y);
        }
        else
        {
            Debug.Log("Case A");
            targetPosition = new Vector3(transform.position.x, -transform.position.z, transform.position.y);
            if (currEnvRot.y == -90 || currEnvRot.y == 270)
            {
                Debug.Log("edge case");
                newRotation.z -= 90;
            }
            else if (currEnvRot.y == 180)
            {
                newRotation.x = -90;
            }
            else
            {
                newRotation.x += 90;
            }
            //newRotation = new Vector3(currEnvRot.x + 90, currEnvRot.y, currEnvRot.z);
            zRotation = transform.eulerAngles.y;
        }
        environment.Shift(newRotation);
        transform.position = targetPosition;
        if (environment.transform.eulerAngles.y != 0)
        {
            ResetYRotation();
        }
        Debug.Log("Prev rotation: " + currEnvRot);
        Debug.Log("New rotation: " + newRotation);
        StartCoroutine("CorrectZRotation");
    }

    void ResetYRotation()
    {
        Debug.Log("Resetting Y: was " + environment.transform.eulerAngles + ", Position was: " + transform.position);
        float yRotation = environment.transform.eulerAngles.y;
        Vector3 newPos = transform.position;
        float yCorrection = 0f;
        if (yRotation > -95 && yRotation < -85 || yRotation == 270)
        {
            newPos.x = transform.position.z;
            newPos.z = -transform.position.x;
            yCorrection = 90f;
        } 
        else if (175 < yRotation || yRotation < 5)
        {
            newPos.x = -transform.position.x;
            newPos.z = -transform.position.z;
            yCorrection = 180f;
        }
        else if (yRotation < 95 && yRotation > 85 || yRotation == -270)
        {
            newPos.x = -transform.position.z;
            newPos.z = transform.position.x;
            yCorrection = -90f;
        }
        transform.position = newPos;
        transform.Rotate(new Vector3(0, yCorrection, 0));
        environment.transform.eulerAngles = new Vector3(environment.transform.eulerAngles.x, 0, environment.transform.eulerAngles.z);
        Debug.Log("Correction: " + yCorrection + ", Rotation Now: " + environment.transform.eulerAngles + ", Position now: " + transform.position);
        //player.transform.RotateAround(player.transform.position, Vector3.Cross(player.transform.up, hit.transform.up), 90f);
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
