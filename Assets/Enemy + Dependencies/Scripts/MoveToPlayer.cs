using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform goal;              // Player Transform.
    public float offset = 2f;           // Offset once object is close to player to prevent collision. 
    public int count;
    int damp = 5;                       // we can change the slerp velocity here
    [SerializeField] float moveSpeed = 10f;

    private void Start()
    {
        goal = FindObjectOfType<InputManager>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count > 5)
        {
            count = 0;

        }

        var rotationAngle = Quaternion.LookRotation(goal.position - transform.position); // we get the angle has to be rotated
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * damp); // we rotate the rotationAngle 

        if (Vector3.Distance(goal.position, transform.position) >= offset)
        {
            //Vector3 direction = goal.position - transform.position;
            transform.Translate(transform.forward * Time.deltaTime * moveSpeed);
        }
    }
}
