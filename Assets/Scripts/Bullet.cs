using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

        AudioSource effectAudio = effect.GetComponent<AudioSource>();

        effectAudio.Play();

        Destroy(gameObject);
        Destroy(effect, 0.3f);
    }

}
