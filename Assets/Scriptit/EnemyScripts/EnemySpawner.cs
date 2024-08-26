using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    private float timeUntilSpawn;
    private int enemiesSpawned = 0;
    public int maxSpawns;


    void Awake()
    {
        SetTimeUntilSpawn();
    }
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if(timeUntilSpawn <= 0 && enemiesSpawned < maxSpawns)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemiesSpawned++;
            SetTimeUntilSpawn();
        }
        if(enemiesSpawned >= maxSpawns)
        {
            Destroy(gameObject);
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

}
