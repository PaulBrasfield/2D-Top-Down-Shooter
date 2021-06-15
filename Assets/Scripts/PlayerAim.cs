using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAim : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    public CharacterController controller;

    public Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private Animator aimAnimator;

    public Transform[] firePoints;
    public Transform weapon;

    private void Awake() {
        aimTransform = GameObject.FindGameObjectWithTag("Player").transform;
        aimGunEndPointTransform = GameObject.FindGameObjectWithTag("Gun Endpoint").transform;
        aimAnimator = aimTransform.GetComponent<Animator>();

        controller = GetComponent<CharacterController>();
    }
    

    private void Update() {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming() {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        //Debug.Log(angle);
    }

    private void HandleShooting() {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

            aimAnimator.SetBool("isShooting", true);
            aimAnimator.SetTrigger("Shoot");

            Instantiate(weapon, firePoints[0].position, firePoints[0].rotation);
            Instantiate(weapon, firePoints[1].position, firePoints[1].rotation);

            

            OnShoot?.Invoke(this, new OnShootEventArgs {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition
            });
        } else {
            aimAnimator.SetBool("isShooting", false);
            //aimAnimator.StopPlayback();
        }
    }
}
