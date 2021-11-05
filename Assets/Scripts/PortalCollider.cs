using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollider : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverlapping = false;
    public bool playerJustTeleported = false;

    void Update() {
        if (playerIsOverlapping && !playerJustTeleported) {
            Vector3 portalToPlayer = player.position - transform.position;
            
            // teleport
            float rotationDifference = Quaternion.Angle(transform.rotation, receiver.rotation);
            rotationDifference += 180f;
            player.Rotate(transform.up, rotationDifference);

            Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
            player.position = receiver.position + positionOffset;

            playerIsOverlapping = false;
            receiver.GetComponent<PortalCollider>().playerJustTeleported = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            Debug.Log("Player Entered");
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.name == "Player") {
            Debug.Log("Player Exited");
            playerIsOverlapping = false;
            playerJustTeleported = false;
        }
    }
}
