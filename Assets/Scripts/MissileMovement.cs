using System;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 100f;

    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        var dir = (target.position - transform.position).normalized;
        float rotateAmount = Vector3.Cross(dir, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotationSpeed;

        rb.linearVelocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Missile hit the player!");
            Destroy(gameObject);
        }
    }

    public void TocarDano(float daño)
    {
        Destroy(gameObject);
    }

}
