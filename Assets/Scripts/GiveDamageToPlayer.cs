using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamageToPlayer : MonoBehaviour
{

    public PlayerHealthManager playerHealthManager;

    public int damageToGive;


    void Start()
    {
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();   
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.collider.tag == "Player" && playerHealthManager.canTakeDamage == true) {
            playerHealthManager.TakeDamage(damageToGive);
        }
    }

}
