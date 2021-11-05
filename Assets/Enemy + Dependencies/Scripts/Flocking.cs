using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    GameObject[] Swarm;         // Array to store all of the enemies present in the scene
    public float offset = 2f;   // Offset between enemies

    // Start is called before the first frame update
    void Start()
    {
        Swarm = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject drone in Swarm)
        {
            if(drone != gameObject)
            {
                float distance = Vector3.Distance(drone.transform.position, this.transform.position);
                if (distance <= offset)
                {
                    Vector3 direction = transform.position - drone.transform.position;
                    transform.Translate(direction * Time.deltaTime);
                }
            }
        }
    }
}
