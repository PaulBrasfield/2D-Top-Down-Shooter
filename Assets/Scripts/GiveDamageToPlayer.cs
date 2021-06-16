using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamageToPlayer : MonoBehaviour
{

    public PlayerHealthManager playerHealthManager;

    public PlayerShieldManager playerShieldManager;

    public int damageToGive;


    void Start()
    {
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();   
        playerShieldManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShieldManager>(); 
    }

    void OnCollisionEnter2D(Collision2D col) {
        int shieldDamage = (damageToGive / 2);
        if ((col.collider.tag == "Player" && playerHealthManager.canTakeDamage == true)) {
            playerHealthManager.TakeDamage(damageToGive);
        }

        if (col.collider.tag == "Shield Ring") {
            playerShieldManager.TakeDamage((int)(damageToGive / 2));
            Debug.Log("Damage To Shield: " + shieldDamage);
        }
    }

}
