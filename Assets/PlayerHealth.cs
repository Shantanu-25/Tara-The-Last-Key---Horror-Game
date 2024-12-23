using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // The maximum health of the player
    private int currentHealth;  // The player's current health

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the player's health to the maximum health at the start
        currentHealth = maxHealth;
    }

    // Method to apply damage to the player
    public void TakeDamage(int damageAmount)
    {
        // Reduce the current health by the damage amount
        currentHealth -= damageAmount;

        // Print the player's current health to the console (for debugging)
        Debug.Log("Player took damage: " + damageAmount + ". Current health: " + currentHealth);

        // Check if the player's health has dropped to or below zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to handle the player's death
    private void Die()
    {
        // Here, you could trigger a death animation, game over logic, etc.
        Debug.Log("Player has died!");

        // For now, we'll just disable the player GameObject
        gameObject.SetActive(false);

        // You could also implement a respawn or reload level logic here
        // For example: UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }

    // Method to heal the player (optional)
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        // Ensure that the current health doesn't exceed the maximum health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player healed: " + healAmount + ". Current health: " + currentHealth);
    }
}