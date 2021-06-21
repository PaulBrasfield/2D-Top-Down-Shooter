using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    //private PlayerShieldManager playerShieldManager;
    public PlayerHealthManager playerHealthManager;
    private AudioSource pickupSound;
    public int healthToGive;

    void Start()
    {
        //playerShieldManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShieldManager>();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();

        pickupSound = GetComponent<AudioSource>();
        pickupSound.enabled = false;
    }

    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            if (playerHealthManager.currentHealth != playerHealthManager.maxHealth) {
                playerHealthManager.GiveHealth(healthToGive);
                pickupSound.enabled = true;
                pickupSound.Play();

                this.enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().isTrigger = false;
                GetComponent<Collider2D>().enabled = false;

                Destroy(gameObject, pickupSound.clip.length);
            }
        }
    }
}

