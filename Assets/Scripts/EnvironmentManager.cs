using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    Transform player;
    [SerializeField] Transform zRotationOffset;
    [SerializeField] GameObject enemyPrefab;
    List<GameObject> enemies;
    
    public void Shift(Vector3 newRotation)
    {
        // Determine which wall becomes the floor based on player rotation
        //transform.Rotate(newRotation);
        transform.eulerAngles = newRotation;
    }

    public void ShiftEnemies(int direction)
    {
        if (direction == 2)
        {
            foreach(GameObject enemy in enemies){
                enemy.transform.position = new Vector3(enemy.transform.position.y, -enemy.transform.position.x, enemy.transform.position.z);
            }
        }
        else if (direction == 3)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.z, -enemy.transform.position.y);
            }
        }
        else if (direction == 4)
        {

            foreach (GameObject enemy in enemies)
            {
                enemy.transform.position = new Vector3(-enemy.transform.position.y, enemy.transform.position.x, enemy.transform.position.z);
            }
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x, -enemy.transform.position.z, enemy.transform.position.y);
            }
        }
    }

    public void ShiftAxis(Vector3 axis, float amount)
    {
        // Determine which wall becomes the floor based on player rotation
        //transform.Rotate(newRotation);
        //transform.eulerAngles = newRotation;
        transform.RotateAround(transform.position, axis, amount);
    }

    public void SpawnEnemy()
    {
        enemies.Add(Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity));
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<InputManager>().transform;
        enemies = new List<GameObject>();
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
