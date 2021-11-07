using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    int threshold = 40;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed);
        
        Vector3 loopedPos = transform.position;
        if (Mathf.Abs(transform.position.x) > threshold)
        {
            loopedPos.x = -transform.position.x;
            transform.position = loopedPos;
        } else if (Mathf.Abs(transform.position.y) > threshold)
        {
            loopedPos.y = -transform.position.y;
            transform.position = loopedPos;
        }
        else if (Mathf.Abs(transform.position.z) > threshold)
        {
            loopedPos.z = -transform.position.z;
            transform.position = loopedPos;
        }
    }
}
