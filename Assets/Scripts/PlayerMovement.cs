
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jumpForce;

    public float climbSpeed; // 6f
    public bool isOnLadder = false;
    private float normalGravity;

    private float horizontalInput;
    private bool isGrounded;
    public bool jump;

    public float speedPlane;
    public bool plane;
    public bool isPlaneing = false;

    public float gravityNormal;
    public int numJumps;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private Vector2 initialPosition;

    public int numVidas; // Serán 5 vidas

    public bool isPaused = false;

    public bool muerto = false;

    public bool isJumping = false;

    public Animator animator;

    public AudioClip jumpSound;
    public AudioClip runSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        numJumps = maxJumps;
        initialPosition = transform.position;
        normalGravity = rb.gravityScale;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        /*if(Math.Abs(horizontalInput) < 0.05f)
        {
            animator.SetFloat("movement", 0f);
        }
        else
        {
            animator.SetFloat("movement", Math.Abs(horizontalInput));
        }*/
        jump = Input.GetKeyDown(KeyCode.Space) || jump;
        plane = Input.GetKey(KeyCode.LeftShift);


        if (isOnLadder)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.gravityScale = 0;
                rb.linearVelocity = new Vector2(rb.linearVelocityX/2, climbSpeed);
            }else if (Input.GetKey(KeyCode.S))
            {
                rb.gravityScale = 0;
                rb.linearVelocity = new Vector2(rb.linearVelocityX/2, -climbSpeed);
            }
            else
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            }
        }
        else
        {
            rb.gravityScale = normalGravity;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if(numVidas <= 0)
        {
            muerto = true;
            StopGame();
        }
    }

    void FixedUpdate()
    {
        if (!muerto)
        {
            HorizontalVelocity();
            Jump();
            Planear();
            animator.SetBool("plane", isPlaneing);
            Winner();
            animator.SetBool("clambing", isOnLadder);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            StopGame();
        }
        
    }

    void HorizontalVelocity()
    {
        
        float velocity = speed * horizontalInput;
        animator.SetFloat("movement", Math.Abs(horizontalInput)*velocity);
        rb.linearVelocityX = velocity;    
        if (horizontalInput > 0.05f) // mirando derecha
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < -0.05f) // mirando izquierda
            transform.localScale = new Vector3(-1, 1, 1);
        
        //animator.SetFloat("movement", horizontalInput);
    }

    void Jump()
    {
        if (numJumps > 0)
        {
            if (jump && numJumps > 0)
            {
                isJumping = true;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                if(jumpSound !=null && audioSource != null)
                {
                    audioSource.PlayOneShot(jumpSound);
                }
                numJumps --;
                
                jump = false;
            }
        }
        else
        {
            // Evitamos la acumulación de saltos
            jump=false;
        }
    }

    void Winner()
    {
        if(transform.position.x >= 620f && transform.position.y < 5f)
        {
            Debug.Log("Has ganado!");
            //AudioListener.pause = true;
            Time.timeScale = 0f;
        }
    }
    void StopGame()
    {
        Debug.Log("Game Over");
        rb.linearVelocity = Vector2.zero;
        // muerto = true;
        //AudioListener.pause = true;
        //Time.timeScale = 0f;
    }
    void Planear()
    {
        if (!isGrounded && plane){
            rb.gravityScale = 0;
            rb.linearVelocityY = -speedPlane;
            /*if(rb.linearVelocityY > 0)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        
            rb.gravityScale = gravityPlane;*/
            isPlaneing = true;
        }
        else{
            rb.gravityScale = gravityNormal;
            isPlaneing = false;
        }
    }

    void Reset()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        
    }

    void Pause()
    {
        if (isPaused)
        {
            AudioListener.pause = false;
            Time.timeScale = 1f;
            isPaused = false;
            Debug.Log("Juego reanudado");
        }
        else
        {
            if (numVidas > 0)
            {
                AudioListener.pause = true;
                Time.timeScale = 0f;
                isPaused = true;
                Debug.Log("Juego pausado");
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            numJumps = maxJumps;
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Missile"))
        {
            //Debug.Log("Player hit by missile!");
            numVidas--;
            Debug.Log("Vidas restantes: " + numVidas);
        }

        if(collision.gameObject.tag == "Destroy")
        {
            muerto = true;
            StopGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
        }
    }
}
