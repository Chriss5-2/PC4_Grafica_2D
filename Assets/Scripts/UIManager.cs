using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Runtime.InteropServices.WindowsRuntime;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI nivelDescomposicion;
    public TextMeshProUGUI metrosFaltantes;

    public float posicionMeta = 620f;
    public float distanciaRestante;
    public float numVidas;
    public AudioClip GameOverSound;
    public AudioClip WinSound;
    private AudioSource audioSource;
    public float sizeGO = 10f;

    private bool gameOverSonado = false;
    private bool winSonado = false;

    void Start()
    {
        numVidas = player.GetComponent<PlayerMovement>().numVidas;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        /*
        if (player.GetComponent<PlayerMovement>().muerto)
        {
            // Aumenta el tamaño con el tiempo (no con un for)
            audioSource.PlayOneShot(GameOverSound);
            sizeGO += Time.deltaTime * 80f;  // velocidad del crecimiento
            sizeGO = Mathf.Clamp(sizeGO, 0f, 100f);

            nivelDescomposicion.fontSize = sizeGO;
            nivelDescomposicion.text = "GAME OVER";

            // Poner en la posicion 0, 0, 0
            nivelDescomposicion.rectTransform.anchoredPosition = new Vector2(-290f, -1f);

            // Centrando el texto
            nivelDescomposicion.alignment = TextAlignmentOptions.Center;
        }
        else
        {
            float numDescomposicion = (numVidas - player.GetComponent<PlayerMovement>().numVidas)*10;
            string descomposicion = (numDescomposicion).ToString();
            nivelDescomposicion.text = "Descomposición: " + descomposicion + "%";

            if(player.transform.position.x >= 620f && player.transform.position.y < 5f)
            {
                audioSource.PlayOneShot(WinSound);
                sizeGO += Time.deltaTime * 80f;  // velocidad del crecimiento
                sizeGO = Mathf.Clamp(sizeGO, 0f, 100f);

                nivelDescomposicion.fontSize = sizeGO;
                nivelDescomposicion.text = "¡Has ganado!";
                nivelDescomposicion.rectTransform.anchoredPosition = new Vector2(-290f, -1f);
                nivelDescomposicion.alignment = TextAlignmentOptions.Center;
            }
        }*/
        PlayerMovement pm = player.GetComponent<PlayerMovement>();

        // Distancia restante con 2 decimales
        distanciaRestante = posicionMeta-pm.transform.position.x;
        if(distanciaRestante < 0f)
        {
            distanciaRestante = 0f;
        }
        metrosFaltantes.text = "Meta: " + (distanciaRestante).ToString("F2");

        if (pm.muerto)
        {
            // 1. SONIDO (SOLO UNA VEZ)
            if (!gameOverSonado) 
            {
                audioSource.PlayOneShot(GameOverSound);
                gameOverSonado = true; // Marcamos que ya sonó para que no repita
                sizeGO = 10f;
            }

            // 2. ANIMACIÓN (TODO EL TIEMPO)
            sizeGO += Time.unscaledDeltaTime * 80f; 
            sizeGO = Mathf.Clamp(sizeGO, 0f, 100f);

            nivelDescomposicion.fontSize = sizeGO;
            nivelDescomposicion.text = "GAME OVER";
            nivelDescomposicion.rectTransform.anchoredPosition = new Vector2(-290f, -1f);
            nivelDescomposicion.alignment = TextAlignmentOptions.Center;
        }
        else
        {
            // LÓGICA DE VIDA
            float numDescomposicion = (numVidas - pm.numVidas) * 10;
            string descomposicion = (numDescomposicion).ToString();
            
            if (!winSonado) 
            {
                nivelDescomposicion.text = "Descomposición: " + descomposicion + "%";
            }

            if(player.transform.position.x >= 620f && player.transform.position.y < 5f)
            {
                // 1. SONIDO (SOLO UNA VEZ)
                if (!winSonado)
                {
                    audioSource.PlayOneShot(WinSound);
                    winSonado = true; // Marcamos que ya sonó
                    sizeGO = 10f;
                }

                // 2. ANIMACIÓN
                sizeGO += Time.unscaledDeltaTime * 80f;  
                sizeGO = Mathf.Clamp(sizeGO, 0f, 100f);

                nivelDescomposicion.fontSize = sizeGO;
                nivelDescomposicion.text = "¡Has ganado!";
                nivelDescomposicion.rectTransform.anchoredPosition = new Vector2(-290f, -1f);
                nivelDescomposicion.alignment = TextAlignmentOptions.Center;
            }
        }
    }
    void GameOver()
    {
        nivelDescomposicion.text = "GAME OVER";
        // Cambiando el tamaño de fuente
        
    }
}
