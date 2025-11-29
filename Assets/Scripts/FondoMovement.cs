using UnityEngine;

public class FondoMovement : MonoBehaviour
{
    public GameObject player;
    public Camera cam;

    public float zoomLejos;
    public float zoomCerca;

    void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 0, 1) - player.transform.position / 1000000000000000000f;
        
        if(cam.orthographicSize == zoomCerca)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }else if(cam.orthographicSize == zoomLejos)
        {
            transform.localScale = new Vector3(2.11f, 1.499f, 1f);
        }
    }
}
