using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject objectToSpawn; // Reference to the prefab to be spawned
    public float spawnRangeX = 10f; // Range in X axis
    public float spawnRangeY = 10f; // Range in Y axis

    // Function to spawn the object
    public void SpawnObject()
    {
        // Generate random position within the specified range
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Instantiate the object at the random position
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }

    // Example of calling SpawnObject function (you can call this from another script or an event)
    void Start()
    {
        SpawnObject();
    }
}
