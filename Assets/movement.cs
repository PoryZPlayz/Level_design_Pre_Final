using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float pushbackForce = 10f; // Adjust the pushback force as needed
    public Rigidbody rb; // Reference to the player's Rigidbody component

    void FixedUpdate()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal"); // Horizontal axis for left and right movement
        float moveVertical = Input.GetAxis("Vertical"); // Vertical axis for forward and backward movement

        // Calculate movement direction based on input
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Move the player
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Calculate the direction from the player to the collision point on the wall
            Vector3 pushbackDirection = (transform.position - collision.contacts[0].point).normalized;

            // Apply a force to push the player away from the wall
            rb.AddForce(pushbackDirection * pushbackForce, ForceMode.Impulse);
        }
    }
}
