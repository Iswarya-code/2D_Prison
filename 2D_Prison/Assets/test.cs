using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Rigidbody2D rb;
   [SerializeField] float speed = 10f;

  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()

    {
        var horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal, 0) *speed *Time.deltaTime;
    }

    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.gameObject.tag == "red")
         {
             Destroy(collision.gameObject);
         }
     }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "red")
        {
            Destroy(collision.gameObject);
        }
    }
}
