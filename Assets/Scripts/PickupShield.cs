using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShield : MonoBehaviour
{
    private PlayerShieldManager playerShieldManager;
    private PlayerHealthManager playerHealthManager;

    private AudioSource pickupSound;

    public int shieldToGive;
    
    void Start()
    {
        playerShieldManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShieldManager>();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();

        pickupSound = GetComponent<AudioSource>();
    }

    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            if (playerShieldManager.currentShield != playerShieldManager.maxShield) {
                playerHealthManager.hasShield = true;
                playerShieldManager.GiveShield(shieldToGive);
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
