using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed = 10f;
    public Transform FirePoint;
    public GameObject homeScreen; // Assign in the Inspector

    public Player player; // Reference to the player to get the facing direction




    #region double click
    //Double click
    /* private float doubleClickTimeThreshold = 0.5f; // Adjust as needed
     private float lastClickTime = 0f;
     private bool isDoubleClick = false;*/
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GetComponent<Player>(); // Make sure the Player script is attached
        }

    }

    // Update is called once per frame
    void Update()
    {
       

        #region Double Click
        /* if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
         {
             if (Time.time - lastClickTime < doubleClickTimeThreshold)
             {
                 // Double click detected
                 isDoubleClick = true;
                 Shoot();
                 Debug.Log("Double click detected!");
             }
             else
             {
                 // Reset double click detection
                 isDoubleClick = false;
             }

             lastClickTime = Time.time;
         }*/
        #endregion

        if (Input.GetMouseButtonDown(0)) 
        {
            // Check if the home screen is active before shooting
            if (homeScreen.activeInHierarchy)
            {
                Debug.Log("Home screen is active. Shooting disabled.");
                return;
            }
            Shoot();


        }


    }

    public  void Shoot()
    {
        float direction = player.isFacingRight ? 1f : -1f; // 1 for right, -1 for left

        SoundManager.instance.PlayShootSound();

        GameObject tempBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = tempBullet.GetComponent<Rigidbody2D>();
       // rb.velocity = transform.right * BulletSpeed; // Adjust direction and speed as needed
        rb.velocity = new Vector2(direction * BulletSpeed, 0f); // Set direction based on player


    }
}
