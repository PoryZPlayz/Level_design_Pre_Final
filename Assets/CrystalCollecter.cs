using UnityEngine;

public class CrystalCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a crystal
        if (other.CompareTag("Crystal"))
        {
            // Get the Rigidbody component of the crystal
            Rigidbody crystalRigidbody = other.GetComponent<Rigidbody>();

            // Disable the collider
            other.enabled = false;

            // Make sure the Rigidbody is kinematic
            if (crystalRigidbody != null)
            {
                crystalRigidbody.isKinematic = true;
            }

            // Destroy the crystal after a short delay
            Destroy(other.gameObject, 0.1f); // Adjust the delay if needed

            // You can add your code here to do something with the collected crystal
            // For example, increase a score or update UI

            // You can also play a sound effect or particle effect
        }
    }
}
