using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchLight : MonoBehaviour
{
    public Light2D playerTorchLight; // Reference to the player's torch light (Point Light 2D)
    public Light2D globalLight; // Reference to the Global Light 2D

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the torch
        if (other.CompareTag("Player"))
        {
            // Disable the global lighting to darken the scene
            globalLight.intensity = 0;

            // Enable the player's torchlight
            playerTorchLight.intensity = 1;

            // Destroy or deactivate the torch object
            Destroy(gameObject); // Or other logic to disable the torch
        }
    }
}
