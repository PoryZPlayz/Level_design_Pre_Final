using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float respawnHeight = -10f; // Height at which the player respawns
    public Transform respawnPoint; // Respawn point for the player

    private void Update()
    {
        // Check if the player's height is below the respawn threshold
        if (transform.position.y < respawnHeight)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        // Move the player to the respawn point
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        // Reset any other player state or variables if needed
    }
}

