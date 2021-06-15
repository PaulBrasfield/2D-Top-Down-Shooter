using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    public int enemyCurrentHealth;

	public GameObject deathEffect;
	public AudioClip deathEffectClip;

	public EnemyHealthBar enemyHealthBar;

	private Quaternion rotation;


	void Awake() {
		rotation = enemyHealthBar.transform.rotation;
	}

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;

    }

	void Update() {

		if (enemyCurrentHealth > enemyMaxHealth) {
            enemyCurrentHealth = enemyMaxHealth;
        } 

        if (enemyCurrentHealth < 0) {
            enemyCurrentHealth = 0;
        }

		if (enemyCurrentHealth == 0) {
			KillEnemy();
		}

	}

	void LateUpdate() {
		enemyHealthBar.transform.rotation = rotation;
	}
    public void TakeDamage(int damage) {
        enemyCurrentHealth -= damage;
		enemyHealthBar.SetHealth(enemyCurrentHealth);
		//Debug.Log("Enemy Health: " + enemyCurrentHealth);
    }

    public void GiveHealth(int health) {
        enemyCurrentHealth += health;
		enemyHealthBar.SetHealth(enemyCurrentHealth);
    }

	public void KillEnemy() {
		GameObject effect = Instantiate(deathEffect, this.gameObject.transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(deathEffectClip, this.transform.position);

		Destroy(GameObject.FindGameObjectWithTag("Enemy Health Bar"));
		Destroy(this.gameObject);
		Destroy(effect, 1f);
	}
}
