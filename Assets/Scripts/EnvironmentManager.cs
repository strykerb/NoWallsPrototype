using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    Transform player;
    [SerializeField] Transform gazeCoordinate;
    
    public void Shift()
    {
        Debug.Log("Shift.");
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x += 90;
        transform.eulerAngles = targetRotation;

        Vector3 targetPosition = new Vector3(player.position.x, player.position.z, player.position.y);
        player.position = targetPosition;
    }

    public Transform CalculateNewGaze(Vector3 hitPoint)
    {
        gazeCoordinate.position = hitPoint;
        Shift();
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
