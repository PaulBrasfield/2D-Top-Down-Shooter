using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform[] firePoints;
    public GameObject bulletPrefab;

    public GameObject destroyEffect;

    public float bulletForce = 20f;

    private AudioSource bulletAudio;

    public AnimationClip destroyEffectClip;

    void Start()
    {
        bulletAudio = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        GameObject bullet1 = Instantiate(bulletPrefab, firePoints[0].position, firePoints[0].rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoints[1].position, firePoints[1].rotation);

        Rigidbody2D bullet1RB = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D bullet2RB = bullet2.GetComponent<Rigidbody2D>();

        bullet1RB.AddForce(firePoints[0].up * bulletForce, ForceMode2D.Impulse);
        bullet2RB.AddForce(firePoints[1].up * bulletForce, ForceMode2D.Impulse);
        bulletAudio.Play();
    }
}
