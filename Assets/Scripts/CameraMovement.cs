using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Camera cam;              // opcional: arrastra la Main Camera aquí
    public float zoomLejos;
    public float zoomCerca;


    void Update()
    {
        if(player.transform.position.x > 397f && player.transform.position.x < 500f)
        {
            cam.orthographicSize = zoomLejos;
        }
        else if(player.transform.position.x >= 500f && player.transform.position.y < 4f)
        {
            cam.orthographicSize = zoomCerca;
        }
        else
        {
            cam.orthographicSize = zoomCerca;
        }
        
        // mantén la cámara siguiendo al jugador en Z = -1 (igual que antes)
        transform.position = player.transform.position + new Vector3(0, 0, -1);
    }
}
