using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    Transform player;
    [SerializeField] Transform gazeCoordinate;
    
    public void Shift()
    {
        // Determine which wall becomes the floor based on player rotation
        float rot = player.eulerAngles.y;
        Vector3 newRotation = Vector3.zero;
        Vector3 targetPosition = Vector3.zero;

        if (rot >= 45f && rot < 135f)
        {
            Debug.Log("Case B");
            targetPosition = new Vector3(player.position.y, -player.position.x, player.position.z);
            //newRotation = new Vector3(-transform.eulerAngles.x, 0f, -90f);
            newRotation = new Vector3(0f, 0f, -90f);
        }
        else if (rot >= 135f && rot < 225f)
        {
            Debug.Log("Case C");
            targetPosition = new Vector3(player.position.x, player.position.z, -player.position.y);
            //newRotation = new Vector3(-90f, 0f, -transform.eulerAngles.z);
            newRotation = new Vector3(-90f, 0f, 0f);
        } 
        else if (rot >= 225f && rot < 315f) 
        {
            Debug.Log("Case D");
            targetPosition = new Vector3(-player.position.y, player.position.x, player.position.z);
            //newRotation = new Vector3(-transform.eulerAngles.x, 0f, 90f);
            newRotation = new Vector3(0f, 0f, 90f);
        } 
        else
        {
            Debug.Log("Case A");
            targetPosition = new Vector3(player.position.x, -player.position.z, player.position.y);
            //newRotation = new Vector3(90f, 0f, -transform.eulerAngles.z);
            newRotation = new Vector3(90f, 0f, 0f);
        }

        // Apply specified transformations to player and environment
        
        Debug.Log("prev rot: " + transform.eulerAngles + " , new rot: " + newRotation);
        transform.Rotate(newRotation);
        //transform.eulerAngles += newRotation;
        player.position = targetPosition;
    }

    public Transform CalculateNewGaze(Vector3 hitPoint)
    {
        gazeCoordinate.position = hitPoint;
        Debug.Log("pre-rotate: " + gazeCoordinate.position);
        Shift();
        Debug.Log("post-rotate: " + gazeCoordinate.position);
        return gazeCoordinate;
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
