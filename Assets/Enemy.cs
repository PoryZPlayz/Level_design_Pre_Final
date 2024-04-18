using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;            // Speed of movement
    public float detectionRadius = 10f;     // Radius for detecting the player
    public float attackRange = 2f;          // Range for attacking the player
    public float attackInterval = 2f;       // Time interval between attacks
    public Transform player;                // Reference to the player's transform
    public Animator animator;               // Reference to the animator component

    private bool isFollowingPlayer = false; // Flag to track if the enemy is following the player
    private float lastAttackTime = 0f;      // Time of the last attack

    void Update()
    {
        // Check if the player is within detection radius
        if (!isFollowingPlayer && Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            isFollowingPlayer = true;
        }

        if (isFollowingPlayer)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Check if the player is within attack range
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                // If enough time has passed since the last attack, attack again
                if (Time.time - lastAttackTime >= attackInterval)
                {
                    Attack();
                }
            }

            // Raycast downward to detect the ground
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                // Adjust Y position to match the ground level
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }
        }
    }

    void Attack()
    {
        // Trigger attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Update last attack time
        lastAttackTime = Time.time;
    }
}
