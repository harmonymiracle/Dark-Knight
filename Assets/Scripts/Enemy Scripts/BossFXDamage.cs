using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFXDamage : MonoBehaviour {

	public LayerMask playerLayer;
	public float radius = 10f;
	public float damageCount = 10f;

	private PlayerHealth playerHealth;
	private bool collided;

//	void Awake () {
//		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent <PlayerHealth> ();
//	}
	
	void Update () {
		Collider[] hits = Physics.OverlapSphere (transform.position, radius, playerLayer);

		print (hits.Length);
		foreach (Collider c in hits) {
			playerHealth = c.gameObject.GetComponent <PlayerHealth> ();
			collided = true;
		}

		if (collided) {
			playerHealth.TakeDamage (damageCount);
			enabled = false;
		}
	}
} // class









