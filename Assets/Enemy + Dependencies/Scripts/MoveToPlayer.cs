using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform goal;              // Player Transform.
    public float offset = 2f;           // Offset once object is close to player to prevent collision. 

    private void Start()
    {
        goal = FindObjectOfType<InputManager>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(goal.position, transform.position) >= offset)
        {
            Vector3 direction = goal.position - transform.position;
            transform.Translate(direction * Time.deltaTime);
        }
    }
}
