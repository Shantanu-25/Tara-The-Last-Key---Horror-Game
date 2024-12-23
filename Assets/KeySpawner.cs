using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    // Array of possible spawn points for the key
    public Transform[] spawnPoints;

    // Key prefab that will be instantiated
    public GameObject keyPrefab;

    void Start()
    {
        // Check if keyPrefab and spawnPoints are set
        if (keyPrefab != null && spawnPoints.Length > 0)
        {
            // Randomly select a spawn point from the array
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the key object at the chosen spawn point
            Instantiate(keyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Key prefab or spawn points not set!");
        }
    }
}

