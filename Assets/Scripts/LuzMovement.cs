using UnityEngine;

public class LuzMovement : MonoBehaviour 
{
    public GameObject player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}
