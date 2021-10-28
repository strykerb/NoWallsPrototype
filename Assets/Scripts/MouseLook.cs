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

    float mouseX, mouseY;
    float xRotation = 0f;

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
        playerCamera.eulerAngles = targetRotation;
    }

    void SnapCamera(Transform goalPoint)
    {
        transform.LookAt(goalPoint, Vector3.up);
    }

    private void Start()
    {
        RotationMask = new Vector3(0f, 1f, 0f);
        environment = FindObjectOfType<EnvironmentManager>();
    }

    public void ShiftGaze()
    {
        int layerMask = 1 << 6;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Transform newLookCoordinate = environment.CalculateNewGaze(hit.point);
            SnapCamera(newLookCoordinate);
            //GameObject hitPoint = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), hit.point, Quaternion.identity);
            Debug.Log(hit.point);
        }
    }
}
