using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    private Transform player;

    private Rigidbody2D rb;

    private Animator anim;

    public float moveSpeed = 5;

    Vector2 movement;

    public Transform[] firePoints;
    public GameObject bulletPrefab;

    public GameObject destroyEffect;

    public float bulletForce = 20f;

    public float waitBetweenShots;

    private float shotCounter;

    public PlayerHealthManager playerHealthManager;

    private AudioSource bulletAudio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        if (player == null) {
            Debug.LogError("No Player found!");
        }

        shotCounter = waitBetweenShots;

        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();

        bulletAudio = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerHealthManager.isDead == true) {
            moveSpeed = 0;
            anim.SetBool("isMoving", false);
        } else {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            float distance = (transform.position - player.position).magnitude;

            rb.rotation = angle;

            direction.Normalize();
            movement = direction;

            shotCounter -= Time.deltaTime;

            Debug.DrawLine(transform.position, player.position);

            if (distance < 5) {
                moveSpeed = 0;
                anim.SetBool("isMoving", false);
            } else {
                moveSpeed = 5;
                anim.SetBool("isMoving", true);
            }

            if (distance < 15 && shotCounter < 0) {
                Attack();
            }
        }

    }

    void FixedUpdate() {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        anim.SetBool("isMoving", true);

    }

    void Attack() {
        GameObject bullet1 = Instantiate(bulletPrefab, firePoints[0].position, firePoints[0].rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoints[1].position, firePoints[1].rotation);
        shotCounter = waitBetweenShots;

        Rigidbody2D bullet1RB = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D bullet2RB = bullet2.GetComponent<Rigidbody2D>();

        bullet1RB.AddForce(firePoints[0].up * bulletForce, ForceMode2D.Impulse);
        bullet2RB.AddForce(firePoints[1].up * bulletForce, ForceMode2D.Impulse);
        bulletAudio.Play();
    }
}
