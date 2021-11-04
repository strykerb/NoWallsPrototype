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
        //transform.Rotate(newRotation);
        transform.eulerAngles = newRotation;
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
