using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    // Reference to the player's inventory or key counter
    public int keysCollected = 0; // This will store how many keys the player has

    // Text or UI element to show the number of keys collected (optional)
    public UnityEngine.UI.Text keyCountText; 

    // The distance at which the player can pick up the key
    public float pickupRange = 3f;

    // Reference to the player
    private GameObject player;

    void Start()
    {
        // Get the player object by tag (assuming the player is tagged as "Player")
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Check if the player is within pickup range and if "E" key is pressed
        if (player != null && Vector3.Distance(player.transform.position, transform.position) <= pickupRange)
        {
            // If "E" key is pressed, pick up the key
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpKey();
            }
        }
    }

    void PickUpKey()
    {
        // Increase the key count
        keysCollected++;

        // Update the UI text to show the new key count (optional)
        if (keyCountText != null)
        {
            keyCountText.text = "Keys: " + keysCollected;
        }

        // Destroy the key object after picking it up
        Destroy(gameObject);

        // Alternatively, you can hide the key instead of destroying it:
        // gameObject.SetActive(false);
    }
}


