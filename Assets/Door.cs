using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] GameObject key; // Reference to the key object
    [SerializeField] GameObject gameover; // Reference to the Game Over panel (or Win panel)
    [SerializeField] string playerTag = "Player"; // Tag to identify the player

    private bool hasKey = false;

    // When the player picks up the key
    public void PickUpKey()
    {
        hasKey = true;
        key.SetActive(false); // Hide the key when picked up
        Debug.Log("Key collected!");
    }

    // When the player interacts with the door
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the door area
        if (other.CompareTag(playerTag) && hasKey)
        {
            // Display the game over or win screen
            Debug.Log("You Win!");
            gameover.SetActive(true); // Activate the win screen or game over panel
            // Optionally, stop the game here (if needed)
            Time.timeScale = 0f; // Stops time to "pause" the game, effectively ending it
        }
    }
}