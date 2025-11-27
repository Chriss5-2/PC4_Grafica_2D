using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jumpForce;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numJumps = maxJumps;
        initialPosition = transform.position;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space) || jump;
        plane = Input.GetKey(KeyCode.LeftShift);
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
        transform.position = initialPosition;
        rb.linearVelocity = Vector2.zero;
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
            Debug.Log("Player hit by missile!");
        }

        if(collision.gameObject.tag == "Destroy")
        {
            Reset();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
