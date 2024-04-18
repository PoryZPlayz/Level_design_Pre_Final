using UnityEngine;

public class AddRigidbodyToWalls : MonoBehaviour
{
    void Start()
    {
        // Get all child objects under the "Cave parts" parent GameObject
        Transform caveParts = transform.Find("Cave");
        if (caveParts != null)
        {
            foreach (Transform child in caveParts)
            {
                // Check if the child object does not already have a Rigidbody component
                if (child.GetComponent<Rigidbody>() == null)
                {
                    // Add a Rigidbody component to the child object
                    Rigidbody rb = child.gameObject.AddComponent<Rigidbody>();
                    rb.isKinematic = true; // Make the Rigidbody kinematic to prevent physics simulation
                }
            }
        }
    }
}
