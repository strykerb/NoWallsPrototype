using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] float respawnTime = 3.0f;

    [SerializeField] float spinSpeed = 0.1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.GetComponent<PlayerScore>().score += 1;
            StartCoroutine(respawnTimer());
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            // gameObject.SetActive(false);
        }
    }

    IEnumerator respawnTimer(){
        Debug.Log("respawn timer started");
        yield return new WaitForSeconds(respawnTime);
        Debug.Log("respawn timer finished");
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<MeshCollider>().enabled = true;
        // gameObject.SetActive(true);
    }

    private void Update() {
        transform.Rotate(0f,0f,spinSpeed * Time.deltaTime, Space.Self);
    }
}
