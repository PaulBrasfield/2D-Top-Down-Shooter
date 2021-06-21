using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool hasShield = false;
    public bool isDead;

    public bool canTakeDamage = true;
	public bool canDie = true;

    public bool currentHealthIsMaxHealth;

    public HealthBar healthBar;

    public GameObject deathEffect;
	public AudioClip deathEffectClip;

    public float delayTime;

    private bool startDelayCounter; 

    //public float waitForTime;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

        if (currentHealthIsMaxHealth == true) {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        } else {
            healthBar.SetHealth(currentHealth);
        }

        isDead = false;

        //startDelayCounter = false;

        //delayTime = waitForTime;
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.LeftShift)) {
        //     TakeDamage(10);
        // }

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        } 

        if (currentHealth < 0) {
            currentHealth = 0;
        }

        if (currentHealth == 0 && canDie == true) {
            KillPlayer();
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void GiveHealth(int health) {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

    public void KillPlayer() {
        isDead = true;
        hasShield = false;
		GameObject effect = Instantiate(deathEffect, this.gameObject.transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(deathEffectClip, this.transform.position);

        Destroy(GameObject.FindGameObjectWithTag("Player Health Bar"));
        Destroy(this.gameObject);
        Destroy(effect, 1f);
	}
}
