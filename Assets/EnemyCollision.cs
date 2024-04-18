using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f;

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the projectile collided with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(other.gameObject);
            // Destroy the projectile as well if needed
            Destroy(gameObject);
        }
    }
}
