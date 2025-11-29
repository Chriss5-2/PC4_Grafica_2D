using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    public float timeToFall;
    private Rigidbody2D rb;

    private bool jugadorEncima = false;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public int resetTime=2;

    public AudioClip caerSound;
    private AudioSource audioSource;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            jugadorEncima = true;
            if(caerSound != null)
            {
                audioSource.PlayOneShot(caerSound);
            }
            Invoke("HacerCaer", timeToFall);
            //jugadorEncima=false;
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

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        transform.position = initialPosition;
        transform.rotation = initialRotation;
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
