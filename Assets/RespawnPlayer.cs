using System.Collections;
using UnityEngine;

public class PlayerRespawnNoAnimation : MonoBehaviour
{
    public Transform respawnPoint;
    public float respawnDelay = 2.0f;

    private Rigidbody playerRb;

    // Reference to the player's camera
    public Camera playerCamera;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        // Check if the camera reference is assigned
        if (playerCamera == null)
        {
            Debug.LogError("Player camera is not assigned! Please assign the camera.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("Ghost hit player, starting respawn.");
            StartCoroutine(RespawnWithDelay());
        }
    }

    private IEnumerator RespawnWithDelay()
    {
        Debug.Log("Respawn delay started.");

        playerRb.isKinematic = true;

        // No need to disable the camera anymore
        Debug.Log("Camera remains enabled during respawn delay.");

        // Wait for the respawn delay
        yield return new WaitForSeconds(respawnDelay);

        // Respawn the player
        Respawn();
    }

    private void Respawn()
    {
        Debug.Log("Respawning player.");

        // Move player to the respawn point
        playerRb.position = respawnPoint.position;
        playerRb.linearVelocity = Vector3.zero;
        playerRb.isKinematic = false;

        // Ensure the camera stays active; no need to re-enable it since it's never disabled
        if (playerCamera != null)
        {
            Debug.Log("Player camera is active and has not been disabled.");
        }
        else
        {
            Debug.LogWarning("Player camera is still null after respawn.");
        }
    }
}
