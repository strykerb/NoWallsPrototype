using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    Transform player;
    [SerializeField] Transform zRotationOffset;
    
    public void Shift(Vector3 newRotation)
    {
        // Determine which wall becomes the floor based on player rotation

        transform.Rotate(newRotation);
        //float rot = player.eulerAngles.y;
        //Vector3 newRotation = Vector3.zero;
        //Vector3 targetPosition = Vector3.zero;
        /*
        if (rot >= 45f && rot < 135f)
        {
            Debug.Log("Case B");
            targetPosition = new Vector3(player.position.y, -player.position.x, player.position.z);
            //newRotation = new Vector3(-transform.eulerAngles.x, 0f, -90f);
            newRotation = new Vector3(0f, 0f, -90f);
            zRotationOffset.Rotate(newRotation);
        }
        else if (rot >= 135f && rot < 225f)
        {
            Debug.Log("Case C");
            targetPosition = new Vector3(player.position.x, player.position.z, -player.position.y);
            //newRotation = new Vector3(-90f, 0f, -transform.eulerAngles.z);
            newRotation = new Vector3(-90f, 0f, 0f);
            transform.Rotate(newRotation);
        }
        else if (rot >= 225f && rot < 315f) 
        {
            Debug.Log("Case D");
            targetPosition = new Vector3(-player.position.y, player.position.x, player.position.z);
            //newRotation = new Vector3(-transform.eulerAngles.x, 0f, 90f);
            newRotation = new Vector3(0f, 0f, 90f);
            zRotationOffset.Rotate(newRotation);
        } 
        else
        {
            Debug.Log("Case A");
            targetPosition = new Vector3(player.position.x, -player.position.z, player.position.y);
            //newRotation = new Vector3(90f, 0f, -transform.eulerAngles.z);
            newRotation = new Vector3(90f, 0f, 0f);
            transform.Rotate(newRotation);
        }
        */
        // Apply specified transformations to player and environment

        //Debug.Log("prev rot: " + transform.eulerAngles);

        //transform.eulerAngles += newRotation;
        //Debug.Log("new rot: " + transform.eulerAngles);
        //player.position = targetPosition;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<InputManager>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
