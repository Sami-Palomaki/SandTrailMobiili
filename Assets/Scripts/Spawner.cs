using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float minSpawnTime;
    public float maxSpawnTime;
    public float maxTimeDecreasePerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("Spawn", randomTime);
    }

    void Spawn()
    {
        Instantiate(asteroidPrefab, transform.position, Quaternion.identity);

        float randomTime = Random.Range(minSpawnTime, maxSpawnTime);

        if (maxSpawnTime > minSpawnTime)
        {
            maxSpawnTime -= maxTimeDecreasePerSpawn;
        }

        if (maxSpawnTime <= minSpawnTime)
        {
            maxSpawnTime = minSpawnTime;
        }
        
        // Toteuttaa metodin "Spawn" randomTime ajan kuluttua
        // Mahdollistaa jatkuvan metodi silmukan
        Invoke("Spawn", randomTime);
    }
}
