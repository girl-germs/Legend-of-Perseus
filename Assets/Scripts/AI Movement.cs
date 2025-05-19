using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float followSpeed = 4f; // Speed at which the object follows
    public float stopDistance = 2f; // Distance to stop following the player

    void Update()
    {
        // Check the distance between the object and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Only move if the object is farther than the stop distance
        if (distanceToPlayer > stopDistance)
        {
            // Calculate the direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move towards the player
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }
}
