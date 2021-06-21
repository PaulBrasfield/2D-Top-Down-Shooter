using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControlManager : MonoBehaviour
{
    public GameObject[] spawnEnemy;

    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy = GameObject.FindGameObjectsWithTag("Enemy Spawnpoint");
 
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn == true) {
            for (int i = 0; i < spawnEnemy.Length; i++) {
                spawnEnemy[i].GetComponent<SpawnEnemy>().canSpawn = true;
            }
        }
    }
}
