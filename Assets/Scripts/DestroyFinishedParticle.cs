using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour {
	public float lifeTime;
	public AnimationClip anim;

	// Use this for initialization
	void Start () {
        lifeTime = anim.length;
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;

		if (lifeTime < 0) {
			Destroy(gameObject);
		}

	}
}
