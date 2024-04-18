using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public float moveSpeedThreshold = 0.1f; // Threshold to determine if the player is running

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate player movement speed
        float speed = rb.velocity.magnitude;

        // Set animation parameter based on movement speed
        animator.SetBool("isRunning", speed > moveSpeedThreshold);

        // If the player is not moving (speed is below threshold), set the isIdle parameter to true
        animator.SetBool("isIdle", speed <= moveSpeedThreshold);
    }
}

