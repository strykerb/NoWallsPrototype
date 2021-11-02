using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraA;
    public Camera cameraB;

    public Material cameraMatA;
    public Material cameraMatB;

    public Shader portalShader;
    public PortalCamera[] portalCameras;

    // Start is called before the first frame update
    void Start()
    {

        foreach (PortalCamera portalCamera in portalCameras) {
            
            portalCamera.renderPlane.sharedMaterial = new Material(portalShader);

            Camera cam = portalCamera.GetComponent<Camera>();

            if (cam.targetTexture != null){
                cam.targetTexture.Release();
            }

            cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            portalCamera.renderPlane.sharedMaterial.mainTexture = cam.targetTexture;
        }

        // if (cameraA.targetTexture != null) {
        //     cameraA.targetTexture.Release();
        // }
        // cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        // cameraMatA.mainTexture = cameraA.targetTexture;

        // if (cameraB.targetTexture != null) {
        //     cameraB.targetTexture.Release();
        // }
        // cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        // cameraMatB.mainTexture = cameraB.targetTexture;
    }
}
