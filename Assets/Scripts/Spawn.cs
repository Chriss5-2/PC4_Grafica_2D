using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public int numEnemys;

    public float timeWait;
    private float timer;
    public int SpawnCount;

    void Start()
    {
        timer = timeWait;
        numEnemys=1;
        SpawnCount = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnCount++;
            if (SpawnCount % 5 == 0)
            {
                numEnemys++;
            }
            SpawnMissile(numEnemys);
            timer = timeWait;
        }
    }

    private void SpawnMissile(int cantidad)
    {
        for (int i=0; i < cantidad; i++)
        {
            Vector3 position = new Vector3(Random.Range(-11f, 11f), Random.Range(10f, 20f), 0);
            Instantiate(prefab, position, Quaternion.identity);
        }
        
        //for (int i=0; i< cantidad; i++)
        //{
        //    Vector3 position = new Vector3(Random.Range(-11f, 11f), Random.Range(4f, 8f), 0);
            // Esperando el timeWait

        //    Instantiate(prefab, position, Quaternion.identity);
        //    
        //}
    }

}
