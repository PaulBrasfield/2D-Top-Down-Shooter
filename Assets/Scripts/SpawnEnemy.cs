using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public GameObject[] spawnPoints;

    public float waitBetweenSpawns;

    public float spawnCounter;

    public int enemySpawnedCounter;

    void Start()
    {
        spawnCounter = waitBetweenSpawns;

        spawnPoints = GameObject.FindGameObjectsWithTag("Enemy Spawnpoint");
    }

    void Update()
    {
        spawnCounter -= Time.deltaTime;

        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 5 && spawnCounter < 0 && enemySpawnedCounter <= 3) {
            Spawn();
        }

        if (enemySpawnedCounter >= 4) {
            return;
        }
    }

    void Spawn() {
        int index;
        
        index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[index].transform.position, Quaternion.identity);
        spawnCounter = waitBetweenSpawns;
        enemySpawnedCounter++;
    }
}
