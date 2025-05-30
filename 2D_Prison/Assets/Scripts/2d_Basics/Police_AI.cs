using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Police_AI : MonoBehaviour
{
    [Header("References")]
    public Animator animator;         // Reference to the Animator
    public Transform player;          // Assign your Player GameObject
    public Transform bulletSpawn;     // Point where bullets will be spawned

    public GameObject globalLight;    // Reference to the Global Light GameObject

    [Header("Attack Settings")]
    public float attackRange = 5f;    // Distance to trigger attack
    public float bulletSpeed = 10f;   // Speed of the bullet
    public float shootCooldown = 1f;  // Time between shots

    [Header("Bullet")]
    public GameObject bulletPrefab;   // Bullet prefab to instantiate

    private float shootTimer = 0f;    // Timer for controlling shooting frequency
    private Vector3 originalScale;    // Store the original scale of the police


    public float destroyDelay = 2f;       // Time (seconds) before police is destroyed after Hurt

    private bool isHurtTriggered = false; // So we only trigger Hurt once


    private SpriteRenderer spriteRenderer; //change police sprite color
    private int hitCount = 0;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;

       
    }

    void Update()
    {
        if (player == null)
        {
            animator.SetBool("IsAttacking", false);
            return;
        }

        // Flip police to face the player without changing its size
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        // Calculate distance to player
        float distance = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distance to player: " + distance);

        if (distance <= attackRange)
        {
            animator.SetBool("IsAttacking", true);

            // Shoot if cooldown is ready
            if (shootTimer <= 0f)
            {
                Shoot();
                shootTimer = shootCooldown;
            }
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }

        if (shootTimer > 0f)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        SoundManager.instance.PlayPoliceGunshot();

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float direction = transform.localScale.x > 0 ? 1f : -1f;
            rb.velocity = new Vector2(bulletSpeed * direction, 0);
            //  SpriteRenderer bulletSprite = bullet.GetComponentInChildren<SpriteRenderer>();
            SpriteRenderer bulletSprite = bullet.GetComponent<SpriteRenderer>(); // Get from root


            // Flip bullet sprite if shooting left
            if (bulletSprite != null)
            {
                bulletSprite.flipX = direction < 0;
                // bulletSprite.flipX = true;
            }


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* // If the player collides with police and police not yet hurt
         if (collision.gameObject.CompareTag("Bullet") && !isHurtTriggered)
         {
             isHurtTriggered = true;

             // Stop attacking before triggering hurt
             animator.SetBool("IsAttacking", false);

             // Trigger the hurt animation
             animator.SetTrigger("Hurt");

             // Disable this AI script so shooting stops
             this.enabled = false;

             // Destroy the police after a delay
             StartCoroutine(DestroyAfterHurt());
         }*/

        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitCount++;

            if (hitCount == 1)
            {
                spriteRenderer.color = new Color(1f, 0.6f, 0.6f); // Even lighter red (pinkish)
            }
            else if (hitCount == 2)
            {
                spriteRenderer.color = new Color(0.6f, 0f, 0f); // Darker red
            }
            else if (hitCount >= 3)
            {
                // Trigger Hurt and Death
                animator.SetBool("IsAttacking", false);
                animator.SetTrigger("Hurt");
                this.enabled = false;
                StartCoroutine(DestroyAfterHurt());
            }
           

        }
    }

    
    private IEnumerator DestroyAfterHurt()
    {
        // Wait for the set delay
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the police GameObject
        Destroy(gameObject);
    }
}
