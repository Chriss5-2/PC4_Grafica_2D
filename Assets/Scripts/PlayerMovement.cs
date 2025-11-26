using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jumpForce;

    private float horizontalInput;
    public bool jump;

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
    }

    void FixedUpdate()
    {
        HorizontalVelocity();
        Jump();
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
}
