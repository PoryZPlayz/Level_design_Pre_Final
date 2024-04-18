using UnityEngine;

public class PlayerWallPushback : MonoBehaviour
{
    public float pushbackForce = 5f;
    public float maxPushbackSpeed = 5f;
    public float drag = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag;
    }

    void FixedUpdate()
    {
        // Cast a ray from the player's position in the opposite direction of its velocity
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -rb.velocity.normalized, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                // Calculate pushback direction away from the wall
                Vector3 pushbackDirection = (transform.position - hit.point).normalized;

                // Calculate pushback force based on player's current velocity
                float pushbackSpeed = Mathf.Min(rb.velocity.magnitude + pushbackForce, maxPushbackSpeed);

                // Apply pushback force to the player
                rb.AddForce(pushbackDirection * pushbackSpeed, ForceMode.VelocityChange);
            }
        }
    }
}
