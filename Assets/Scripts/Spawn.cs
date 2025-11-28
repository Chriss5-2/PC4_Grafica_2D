using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public GameObject lemonPrefab;
    public Transform player;
    public int numEnemys;

    public float timeWait;

    public float timeLemon; // Q sea de 30
    private float timerLemon;
    private float timer; 
    public int SpawnCount;
    public int SpawnLemonCount;

    public float baseSpeedMissile = 4f; //4f
    public float speedIncrement; // 2f

    private float currentSpeedMissile;

    public float distanceRandomMissile;
    void Start()
    {
        timer = timeWait;
        timerLemon = timeLemon;
        numEnemys=1;
        SpawnCount = 0;
        currentSpeedMissile = baseSpeedMissile;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerLemon -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnCount++;
            if (SpawnCount % 5 == 0)
            {
                numEnemys++;
                currentSpeedMissile += speedIncrement;
            }
            SpawnMissile(numEnemys);
            timer = timeWait;
        }
        
        if(timerLemon <= 0f)
        {
            SpawnLemonCount++;
            /*if(SpawnLemonCount % 2 == 0)
            {
                timeLemon -= 5f;
            }*/
            SpawnLemon();
            timerLemon = timeLemon;
        }
    }

    private void SpawnMissile(int cantidad)
    {
        for (int i=0; i < cantidad; i++)
        {
            float offsetCalculado = distanceRandomMissile;
            float randomPosition = Random.Range(0f, 1f);
            if (randomPosition < 0.5f)
            {
                distanceRandomMissile *= -1f;
            }
            else
            {
                // float random = Random.Range(1.5f, 2f);
                offsetCalculado *= 1f;
            }
            Vector3 position = new Vector3(player.position.x + offsetCalculado, player.position.y + Random.Range(10f, 20f), 0);
            GameObject newMosca = Instantiate(prefab, position, Quaternion.identity);

            MissileMovement m = newMosca.GetComponent<MissileMovement>();
            if (m != null) 
            {
                m.speed = currentSpeedMissile;
            }
        }
        
        //for (int i=0; i< cantidad; i++)
        //{
        //    Vector3 position = new Vector3(Random.Range(-11f, 11f), Random.Range(4f, 8f), 0);
            // Esperando el timeWait

        //    Instantiate(prefab, position, Quaternion.identity);
        //    
        //}
    }

    private void SpawnLemon()
    {
        // Spawn del limón a 10 unidades a la derecha del jugador
        // float dirX = player.position.x;
        // Vector3 position = new Vector3(dirX + 10f, -0.9f, 0);
        
        // Generando spawn en el punto (135, 23.1, 0)
        Vector3 position = new Vector3(135f, 23.1f, 0);
        Instantiate(lemonPrefab, position, Quaternion.identity);
    }

}
