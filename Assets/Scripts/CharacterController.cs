using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float moveSpeed;

    public Rigidbody2D rb;

    public Camera cam;

    public Animator anim;

    Vector2 movement;
    Vector2 mousePos;

    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();

        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Vertical") > 0) {
            anim.SetBool("isMoving", true);
        } else if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") < 0) {
            anim.SetBool("isMoving", true);
        } else {
            anim.SetBool("isMoving", false);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        Vector2 lookDir = mousePos - rb.position;
        
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}