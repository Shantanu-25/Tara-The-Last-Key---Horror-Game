using UnityEngine;

public class GhostChase : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float chaseRange = 10f; // Distance at which the ghost starts chasing the player
    public float attackRange = 1.5f; // Distance at which the ghost attacks the player
    public float moveSpeed = 5f; // Speed at which the ghost moves
    public int attackDamage = 10; // Damage dealt to the player

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the ghost and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the chase range
        if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer(distanceToPlayer);
        }
    }

    // Method to chase the player if within range
    void ChasePlayer(float distanceToPlayer)
    {
        // If the player is outside the attack range, move towards the player
        if (distanceToPlayer > attackRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime; // Move ghost towards player
        }
        else
        {
            AttackPlayer(); // Attack if within range
        }
    }

    // Method to attack the player
    void AttackPlayer()
    {
        // Find the player's health script
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        // If the player has a health script, apply damage
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Ghost attacked the player!");
        }
    }

    // Visualizes the chase and attack ranges in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
