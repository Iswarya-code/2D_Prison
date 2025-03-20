using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_Bullet : MonoBehaviour
{
    // If you want to destroy the bullet after a short time even if no collision happens, you can add:
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);  // Auto-destroy bullet after 'lifetime' seconds
    }

    // This method is called when the bullet enters a trigger collider
   
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the bullet has hit the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Option 1: Destroy the player (or call player's health/damage method)
            //  Destroy(collision.gameObject);

            // Option 2: Instead of destroying the player, you might want to reduce the player's health.
            // collision.GetComponent<PlayerHealth>()?.TakeDamage(damageAmount);

            // Destroy the bullet after collision
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Optionally destroy the bullet on hitting other objects
            Destroy(gameObject);
        }
    }
}
