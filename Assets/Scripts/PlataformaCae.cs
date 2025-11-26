using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    public float timeToFall;
    private Rigidbody2D rb;

    private bool jugadorEncima = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            jugadorEncima = true;
            Invoke("HacerCaer", timeToFall);
        }

        if(collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
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
