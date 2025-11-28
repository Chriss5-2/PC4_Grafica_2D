using UnityEngine;

public class AudioZone : MonoBehaviour
{
    public AudioSource miAudioSource;

    public AudioClip clipA_Reproducir; 

    private bool yaSono = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca el Player y el sonido no ha sonado todavía
        if (collision.CompareTag("Player") && !yaSono)
        {
            miAudioSource.PlayOneShot(clipA_Reproducir);
            yaSono = true; // Bloqueamos para que no suene doble si el jugador retrocede
        }
    }
}