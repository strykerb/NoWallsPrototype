using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 moveDir;
    [SerializeField] bool xPositive;
    [SerializeField] bool yPositive;
    int threshold = 50;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(moveDir * speed);
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
        Debug.Log(transform.position);
    }
}
