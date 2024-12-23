using UnityEngine;
using UnityEngine.SceneManagement;  // To manage scenes and end the game

public class DoorController : MonoBehaviour
{
    private bool hasKey = false;  // Track if the player has picked up the key

    // This function gets called when the player picks up the key
    public void PickUpKey()
    {
        hasKey = true;
        Debug.Log("Key picked up!");
    }

    // This function gets called when the player collides with the door
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player reaches the door and has the key
        if (other.CompareTag("Player") && hasKey)
        {
            Debug.Log("Player has reached the door with the key. Game over.");
            EndGame();
        }
        else if (other.CompareTag("Player") && !hasKey)
        {
            Debug.Log("Player needs the key to open the door.");
        }
    }

    // This function ends the game (e.g., by loading an end scene or quitting the game)
    private void EndGame()
    {
        // Load the end screen or quit the game here
        // For example, load an end scene
        SceneManager.LoadScene("EndScene");  // Make sure to have an EndScene in your build settings
    }
}
