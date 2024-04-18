using UnityEngine;

public class AnimatorControllerScript : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    void Update()
    {
        // Check if the player is moving
        bool isMoving = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;

        // Update the animator parameters
        animator.SetBool("isRunning", isMoving);
        animator.SetBool("isIdle", !isMoving);
    }
}
