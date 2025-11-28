using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    public float timeToFall;
    private Rigidbody2D rb;

    private bool jugadorEncima = false;

    private Vector3 initialPosition;
    public int resetTime=2;

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            jugadorEncima = true;
            Invoke("HacerCaer", timeToFall);
            Invoke("ResetPlataform", resetTime);
        }

        /*if(collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }*/
    }

    void ResetPlataform()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = initialPosition;
        jugadorEncima = false;
    }

    void HacerCaer()
    {
        if (jugadorEncima)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
