using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    Player player;
    private UI_Manager uiManager;


    [SerializeField] float speed = 10f;
    Rigidbody2D rb;
    Animator anim;

    //UI
    public Text ScoreDisplay;
    public static int score;
    public GameObject gameOverScreen;

    public GameObject[] lifeIcons; // Assign Life1, Life2, Life3 in the Inspector

    private int currentLives = 0; // Start with 0 lives


    //Jump
    [SerializeField] float JumpSpeed = 5f;
    public LayerMask GroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    bool isGrounded;

    //Climb
    public float climbSpeed = 5f;
    private bool isClimbing = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameOverScreen.SetActive(false);
        score = 0;

        // Hide all life icons at the start
        foreach (var life in lifeIcons)
        {
            life.SetActive(false);
        }

        uiManager = FindObjectOfType<UI_Manager>(); // Auto-assign UI_Manager

    }


    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, GroundLayer);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, GroundLayer);  //jump with groundCheck


        #region Flip
        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }
        #endregion

        #region Jump animation
        if (rb.velocity.y > 0)//  && gameObject.tag == "Wall")
        {
            anim.SetFloat("Move", 3);
        }

        if (rb.velocity.y < 1)
        {
            anim.SetFloat("Move", 1);
        }
        #endregion

        #region Climb
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
            rb.velocity = climbVelocity;
        }
        #endregion

        
    }

    // Update is called once per frame
    void Update()
    {
        KeyMoves();


        if (Input.GetButtonDown("Jump") && isGrounded  )
        {
            Jump();
         
        }

        ScoreDisplay.text = score.ToString();

        if(score == 2)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
           
        }
       /* if(!gameOverScreen.activeInHierarchy)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }*/

       

    }


    public void AddLife()
    {
        if (currentLives < lifeIcons.Length)
        {
            lifeIcons[currentLives].SetActive(true); // Show next life
            currentLives++;
        }
    }
    public static void Score()
    {
        score++;
    }
  
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") )
        {
            isClimbing = true;
           rb.gravityScale = 0f ;
            // Enable Climb Text UI

            if (uiManager != null)
            {
                uiManager.ClimbTextEnable();
            }
        }
       

        if (collision.gameObject.CompareTag("Heart"))
        {
            AddLife();
            Destroy(collision.gameObject); // Remove collected life object
            SoundManager.instance.PlayPopupSound();  // Play popup sound

        }

        if (collision.gameObject.CompareTag("PoliceBullet"))
        {
            TakeDamage(1); // Reduce one life
            Destroy(collision.gameObject); // Destroy the bullet after hit
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isClimbing = false;
            rb.gravityScale = 1f;
            // Enable Climb Text UI
            if (uiManager != null)
            {
                uiManager.ClimbTextDisable();
            }

        }
    }
   
    void KeyMoves()
    {
        //Right move
        if(Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Move", 2);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("Move", 1);
        }
        //Left Move
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("Move", 2);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetFloat("Move", 1);
        }

    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);

    }

    void Flip(bool flipRight)
    {
        if (flipRight)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            //gameObject.transform.Rotate(Vector3.up, 0f);
        }
        else
        {
            //gameObject.transform.Rotate(Vector3.up, 180f);
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void Die()
    {
        FindObjectOfType<UI_Manager>().GameOver();
    }

    // Add this method to reduce life when hit by a police bullet
    public void TakeDamage(int damage)
    {
        if (currentLives > 0)
        {
            currentLives--;
            lifeIcons[currentLives].SetActive(false); // Hide one heart
        }

        if (currentLives <= 0)
        {
            Die();  // Call Die() when no lives remain
        }
    }

    
}
