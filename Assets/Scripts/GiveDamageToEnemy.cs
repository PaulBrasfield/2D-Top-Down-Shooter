using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamageToEnemy : MonoBehaviour
{

    public EnemyHealthManager enemyHealthManager;

    public int damageToGive;


    void Start()
    {
        enemyHealthManager = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealthManager>();   
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.collider.tag == "Enemy") {
            enemyHealthManager.TakeDamage(damageToGive);
        }
    }

}
