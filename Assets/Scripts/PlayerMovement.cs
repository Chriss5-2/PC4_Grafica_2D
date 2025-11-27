
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

    public float gravityPlane;
    public bool plane;

    public float gravityNormal;
    public int numJumps;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private Vector2 initialPosition;

    public int numVidas; // Serán 5 vidas

    public bool isPaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numJumps = maxJumps;
        initialPosition = transform.position;
        normalGravity = rb.gravityScale;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space) || jump;
        plane = Input.GetKey(KeyCode.LeftShift);

        if (isOnLadder)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.gravityScale = 0;
                rb.linearVelocity = new Vector2(rb.linearVelocityX, climbSpeed);
            }else if (Input.GetKey(KeyCode.S))
            {
                rb.gravityScale = 0;
                rb.linearVelocity = new Vector2(rb.linearVelocityX, -climbSpeed);
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
            StopGame();
        }
    }

    void FixedUpdate()
    {
        HorizontalVelocity();
        Jump();
        Planear();
    }

    void HorizontalVelocity()
    {
        float velocity = speed * horizontalInput;
        rb.linearVelocityX = velocity;
    }

    void Jump()
    {
        if (numJumps > 0)
        {
            if (jump && numJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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

    void StopGame()
    {
        Debug.Log("Game Over");
        AudioListener.pause = true;
        Time.timeScale = 0f;
    }
    void Planear()
    {
        if (!isGrounded && plane){

            if(rb.linearVelocityY > 0)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        
            rb.gravityScale = gravityPlane;
        }
        else{
            rb.gravityScale = gravityNormal;
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
