using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform goal;              // Player Transform.
    public float offset = 2f;           // Offset once object is close to player to prevent collision. 
    public int count;
    int damp = 5;                       // we can change the slerp velocity here
    [SerializeField] float moveSpeed = 5f;

    private void Start()
    {
        goal = FindObjectOfType<InputManager>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goal.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * moveSpeed);
        /*
        if (Vector3.Distance(goal.position, transform.position) >= offset)
        {
            //Vector3 direction = goal.position - transform.position;
            transform.Translate(transform.forward * Time.deltaTime * moveSpeed);
        }*/
    }

    private void LateUpdate()
    {
        var rotationAngle = Quaternion.LookRotation(goal.position - transform.position); // we get the angle has to be rotated
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime /** damp*/); // we rotate the rotationAngle
        transform.rotation = rotationAngle;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("kill");
            other.gameObject.GetComponent<GameOver>().GameOverActivate();
        }
    }
}
