using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldManager : MonoBehaviour
{
    public int maxShield = 100;
    public int currentShield;

    //public bool shieldActive;

    public bool isBroken;

    public bool canTakeDamage = true;
	public bool canBeDestroyed = true;

    public ShieldBar shieldBar;

    public PlayerHealthManager playerHealthManager;

    public GameObject breakEffect;
	public AudioClip breakEffectClip;

    public GameObject shieldRing;

    public float delayTime;

    private bool startDelayCounter; 

    // Start is called before the first frame update
    void Start()
    {
        currentShield = maxShield;
        shieldBar.SetMaxShield(maxShield);
        isBroken = false;

        shieldRing.SetActive(false);

        startDelayCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            TakeDamage(10);
        }

        if (playerHealthManager.hasShield == true) {
            SetShieldActive();
        } else {
            SetShieldInactive();
        }

        if (currentShield > maxShield) {
            currentShield = maxShield;
        } 

        if (currentShield < 0) {
            currentShield = 0;
        }

        if (currentShield == 0 && canBeDestroyed == true) {
            DestroyShield();
        }
    }

    public void SetShieldActive() {
        shieldRing.SetActive(true);
    }

    public void SetShieldInactive() {
        shieldRing.SetActive(false);
    }

    public void TakeDamage(int damage) {
        currentShield -= damage;
        shieldBar.SetShield(currentShield);
    }

    public void GiveShield(int shield) {
        currentShield += shield;
        shieldBar.SetShield(shield);
    }

    void DestroyShield() {
        isBroken = true;
        playerHealthManager.hasShield = false;
		//GameObject effect = Instantiate(breakEffect, this.gameObject.transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(breakEffectClip, this.transform.position);

        Destroy(GameObject.FindGameObjectWithTag("Player Shield Bar"));
       //Destroy(effect, 1f);
    }
}
