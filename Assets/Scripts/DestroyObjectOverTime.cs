using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour {
    public float lifeTime;
    public GameObject destroyEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            Instantiate(destroyEffect, this.transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
	}
}
