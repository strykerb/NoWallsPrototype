using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping) {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0f){
                // Teleport
                float rotationDifference = Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDifference += 180f;
                player.Rotate(Vector3.up, rotationDifference);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player"){
            playerIsOverlapping = false;
        }
    }
}
