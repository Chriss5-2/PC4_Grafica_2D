using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI nivelDescomposicion;
    public float numVidas;

    void Start()
    {
        numVidas = player.GetComponent<PlayerMovement>().numVidas;
    }

    void Update()
    {
        float numDescomposicion = (numVidas - player.GetComponent<PlayerMovement>().numVidas)*10;
        if(numDescomposicion <= 100f)
        {
            string descomposicion = (numDescomposicion).ToString();
            nivelDescomposicion.text = "Descomposición: " + descomposicion + "%"; 
        }else if(numDescomposicion > 100f || player.GetComponent<PlayerMovement>().muerto)
        {
            nivelDescomposicion.text = "GAME OVER";
            //Invoke("GameOver", 2f);
        }
    }
    void GameOver()
    {
        nivelDescomposicion.text = "GAME OVER";
        // Cambiando el tamaño de fuente
        nivelDescomposicion.fontSize = 100;
        // Centrando el texto
        nivelDescomposicion.alignment = TextAlignmentOptions.Center;
    }
}
