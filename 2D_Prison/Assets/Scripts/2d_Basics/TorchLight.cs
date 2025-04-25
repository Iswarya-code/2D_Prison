using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchLight : MonoBehaviour
{
    public GameObject playerLight; // Assign the Point Light 2D from the Player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerLight != null)
            {
                playerLight.GetComponent<Light2D>().enabled = true;
            }

            Destroy(gameObject); // Remove the torch object
        }
    }
}
