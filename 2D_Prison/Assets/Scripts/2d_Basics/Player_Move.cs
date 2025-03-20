using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Animator anim;

    //Movement
    [SerializeField] float speed = 10f;
    Rigidbody2D rb;

    //jUMP
    public float jumpSpeed = 25f;
   // [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //  float vertical = Input.GetAxis("Vertical");

         rb.velocity = new Vector2(horizontal * speed, 0);
      //  transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;


        KeyMoves();

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
            print("jump");

        }


    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 1f, groundLayer);

    }
    void KeyMoves()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
           // anim.SetFloat("Move", 2);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
           // anim.SetFloat("Move", 1);
        }

    }

   

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0); // Reset Y velocity to avoid double jump
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);


    }



}
