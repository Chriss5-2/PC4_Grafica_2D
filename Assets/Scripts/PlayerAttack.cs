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

        /*if(Input.GetAxisRaw("Horizontal") != 0)
        {
            lookRight = Input.GetAxisRaw("Horizontal") > 0;
        }*/
        if (Input.GetButtonDown("Fire2"))
        {
            Golpe(golpeDerecha, "right");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Golpe(golpeIzquierda, "left");
        }
    }

    private void Golpe(Transform punto, string dir)
    {
        // Transform punto = lookRight ? golpeDerecha : golpeIzquierda;

        Collider2D[] objetos = Physics2D.OverlapCircleAll(punto.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            /*if(lookRight == true)
            {
                direction = "right";
            }
            else
            {
                direction = "left";
            }*/
            
            if (!colisionador.CompareTag("Missile"))
                continue;

            Vector2 dirToEnemy = colisionador.transform.position - punto.position;

            Vector2 golpeDir = (dir == "right") ? Vector2.right : Vector2.left; 

            float dot = Vector2.Dot(dirToEnemy.normalized, golpeDir);

            if (dot <= 0f) // Ajusta este umbral según sea necesario
                continue;
            
            colisionador.transform.GetComponent<MissileMovement>().TocarDano(danoGolpe);
            Debug.Log("Missile hit in the " + dir + " direction!");
            
        }   
    }

    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;
        if(golpeDerecha != null)
        {
            Gizmos.color = Color.red;
            DrawSemiCircle(golpeDerecha.position, radioGolpe, true);
            //Gizmos.DrawWireSphere(golpeDerecha.position, radioGolpe);
        }

        // Gizmos.color = Color.blue;
        if(golpeIzquierda != null)
        {
            Gizmos.color = Color.blue;
            DrawSemiCircle(golpeIzquierda.position, radioGolpe, false);
            //Gizmos.DrawWireSphere(golpeIzquierda.position, radioGolpe);
        }
    }

    private void DrawSemiCircle(Vector3 center, float radius, bool derecha)
    {
        int segments = 30; // más segmentos = curva más suave
        float startAngle = derecha ? -90f : 90f;
        float endAngle   = derecha ? 90f  : 270f;

        Vector3 previousPoint = center + new Vector3(Mathf.Cos(startAngle * Mathf.Deg2Rad),
                                                    Mathf.Sin(startAngle * Mathf.Deg2Rad),
                                                    0) * radius;

        for (int i = 1; i <= segments; i++)
        {
            float t = (float)i / segments;
            float angle = Mathf.Lerp(startAngle, endAngle, t) * Mathf.Deg2Rad;

            Vector3 newPoint = center + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            Gizmos.DrawLine(previousPoint, newPoint);
            previousPoint = newPoint;
        }
    }

}
