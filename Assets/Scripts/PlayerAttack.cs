using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform golpeDerecha;
    [SerializeField] private Transform golpeIzquierda;
    [SerializeField] private float radioGolpe = 1f;
    [SerializeField] private float danoGolpe = 1f;

    public bool lookRight = true;
    private string direction;

    private void Update()
    {

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            lookRight = Input.GetAxisRaw("Horizontal") > 0;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Golpe();
        }
    }

    private void Golpe()
    {
        Transform punto = lookRight ? golpeDerecha : golpeIzquierda;

        Collider2D[] objetos = Physics2D.OverlapCircleAll(punto.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if(lookRight == true)
            {
                direction = "right";
            }
            else
            {
                direction = "left";
            }

            if (colisionador.CompareTag("Missile"))
            {
                colisionador.transform.GetComponent<MissileMovement>().TocarDano(danoGolpe);
                Debug.Log("Missile hit in the " + direction + " direction!");
            }
        }   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(golpeDerecha != null)
        {
            Gizmos.DrawWireSphere(golpeDerecha.position, radioGolpe);
        }

        Gizmos.color = Color.blue;
        if(golpeIzquierda != null)
        {
            Gizmos.DrawWireSphere(golpeIzquierda.position, radioGolpe);
        }
    }
}
