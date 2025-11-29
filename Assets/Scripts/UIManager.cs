using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Runtime.InteropServices.WindowsRuntime;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI nivelDescomposicion;
    public float numVidas;
    public float sizeGO = 0f;

    void Start()
    {
        numVidas = player.GetComponent<PlayerMovement>().numVidas;
    }

    void Update()
    {
        /*if(numDescomposicion <= 100f)
        {
            string descomposicion = (numDescomposicion).ToString();
            nivelDescomposicion.text = "Descomposición: " + descomposicion + "%"; 
        }else if(numDescomposicion > 100f)
        {
            Debug.Log(player.GetComponent<PlayerMovement>().muerto);
            nivelDescomposicion.text = "GAME OVER";
            //Invoke("GameOver", 2f);
        }*/
        if (player.GetComponent<PlayerMovement>().muerto)
        {
            // Aumenta el tamaño con el tiempo (no con un for)
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
        }
    }
    void GameOver()
    {
        nivelDescomposicion.text = "GAME OVER";
        // Cambiando el tamaño de fuente
        
    }
}
