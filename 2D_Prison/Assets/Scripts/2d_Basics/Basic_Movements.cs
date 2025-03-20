using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basic_Movements : MonoBehaviour
{
    //Movement
    [SerializeField] float speed = 10f;
    Rigidbody2D rb;

    //Spawning
    public GameObject[] objectsToSpawn; // Reference to the prefab to be spawned
    public int numberOfObjects = 1; // Number of objects to spawn
    public float spawnRangeX = 10f; // Range in X axis
    public float spawnRangeY = 10f; // Range in Y axis
    public float delay = 0.5f;


    //UI
    public Text ScoreDisplay;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

         rb.velocity = new Vector2(horizontal*speed , vertical*speed );
        // Vector2 movement = new Vector2(x * speed, y * speed);
        // rb.velocity = movement;

        ScoreDisplay.text = score.ToString();

        if(score <0)
        {
            score = 0;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Red"))
            {
            Destroy(collision.gameObject);
            StartCoroutine(SpawnObject());
            score++;
          
        }

        if (collision.gameObject.CompareTag("Blue"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(SpawnObject());
            score++;
        }

        if (collision.gameObject.CompareTag("Pink"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(SpawnObject());
            score++;
        }
       

    }


    IEnumerator  SpawnObject()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            yield return new WaitForSeconds(delay);

            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Generate random position within the specified range
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            float randomY = Random.Range(-spawnRangeY, spawnRangeY);
            Vector2 randomPosition = new Vector2(randomX, randomY);

            // Instantiate the object at the random position
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

        }

    }

}
