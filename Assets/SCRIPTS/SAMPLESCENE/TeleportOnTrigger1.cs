using UnityEngine;

public class TeleportOnTrigger1 : MonoBehaviour
{
    public Transform teleportDestination; // The location where the player will be teleported

    // This method is called when something enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Print the name of the object that touched the trigger
        Debug.Log("Object entered the trigger: " + other.gameObject.name);

        // Check if the object that entered the trigger zone is the player
        if (other.CompareTag("Player"))
        {
            // Calculate the teleport position with an offset in front of the destination
            Vector3 offsetPosition = teleportDestination.position + teleportDestination.up * 5;

            // Teleport the player to the new position with the offset
            other.transform.position = offsetPosition;

            Debug.Log("Player teleported to: " + offsetPosition);
        }
    }
}
