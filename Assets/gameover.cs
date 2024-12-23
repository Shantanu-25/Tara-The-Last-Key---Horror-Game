using UnityEngine;

public class gameover : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;  // Reference to the Game Over UI panel

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Activate the Game Over UI panel
            gameOverPanel.SetActive(true);
        }
    }
}