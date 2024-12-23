using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhostPatrol : MonoBehaviour
{
    public List<Transform> patrolPoints;  // List of patrol points (set in the Unity Inspector)
    public float speed = 2f;              // Speed of the ghost
    public float waitTime = 2f;           // Time to wait at each patrol point
    private int currentPointIndex;        // Index of the current patrol point
    private bool waiting;                 // Flag to indicate waiting
    private float waitCounter;            // Counter for the wait time

    void Start()
    {
        if (patrolPoints.Count == 0)
        {
            Debug.LogError("No patrol points set for Enemy Ghost");
            return;
        }

        // Start at the first patrol point
        currentPointIndex = Random.Range(0, patrolPoints.Count);
        transform.position = patrolPoints[currentPointIndex].position;
        waitCounter = waitTime;
    }

    void Update()
    {
        if (patrolPoints.Count == 0) return;

        // If waiting, decrement the wait counter
        if (waiting)
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0)
            {
                waiting = false;
                currentPointIndex = Random.Range(0, patrolPoints.Count);  // Pick a random next patrol point
            }
        }
        else
        {
            // Move towards the current patrol point
            Transform targetPoint = patrolPoints[currentPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

            // If reached the target point, start waiting
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                waiting = true;
                waitCounter = waitTime;
            }
        }
    }

    // To visualize patrol points in the editor
    void OnDrawGizmos()
    {
        if (patrolPoints == null || patrolPoints.Count == 0) return;

        Gizmos.color = Color.red;
        foreach (Transform point in patrolPoints)
        {
            Gizmos.DrawSphere(point.position, 0.3f);
        }
    }
}