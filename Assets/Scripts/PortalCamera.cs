using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    
    public Transform playerCamera;

    [Header("This Portal")]
    public Transform portal;

    [Header("Other Portal")]
    public Transform targetPortal;
    public MeshRenderer renderPlane;

    private void Start() {
        if (!playerCamera) {
            playerCamera = GameObject.Find("Player").GetComponentInChildren<Camera>().transform;
        }
    }

    void Update()
    {
        // get positional difference and set position
        Vector3 playerOffsetFromPortal = playerCamera.position - targetPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        // get rotational difference and set rotation
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, targetPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
