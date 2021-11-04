using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPair : MonoBehaviour
{
    public Shader portalShader;

    [Header("Player")]
    public Transform player;
    public Transform playerCamera;

    [Header("Positive Portal")]
    public Transform positivePortal;
    public Transform positivePortalCamera;
    public MeshRenderer positivePortalRenderPlane;
    public Transform positivePortalCollider;

    [Header("Negative Portal")]
    public Transform negativePortal;
    public Transform negativePortalCamera;
    public MeshRenderer negativePortalRenderPlane;
    public Transform negativePortalCollider;

    private void Awake() {

        // Setup Both Portals' cameras and materials

        // Render Plane Materials
        positivePortalRenderPlane.sharedMaterial = new Material(portalShader);
        negativePortalRenderPlane.sharedMaterial = new Material(portalShader);

        // get the actual cameras
        Camera posCam = positivePortalCamera.GetComponent<Camera>();
        Camera negCam = negativePortalCamera.GetComponent<Camera>();

        // reset cameras' target textures
        if (posCam.targetTexture != null) posCam.targetTexture.Release();
        if (negCam.targetTexture != null) negCam.targetTexture.Release();

        // set cameras' target textures
        posCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        negCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        // set the render planes' material to the render textures
        positivePortalRenderPlane.sharedMaterial.mainTexture = posCam.targetTexture;
        negativePortalRenderPlane.sharedMaterial.mainTexture = negCam.targetTexture;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setPortalCamera(positivePortal, negativePortal, negativePortalCamera);
        setPortalCamera(negativePortal, positivePortal, positivePortalCamera);
    }

    void setPortalCamera(Transform portalA, Transform portalB, Transform portalACam){
        // get positional difference and set position
        Vector3 playerOffsetFromPortal = playerCamera.position - portalB.position;
        portalACam.position = portalA.position + playerOffsetFromPortal;

        // get rotational difference and set rotation
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portalA.rotation, portalB.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, portalA.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;

        portalACam.rotation = Quaternion.LookRotation(newCameraDirection, portalA.up);
        
    }
}
