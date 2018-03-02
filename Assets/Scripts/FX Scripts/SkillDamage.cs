using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour {


	public LayerMask enemyMask;

	public float radius = 10f;
	public float damageCount = 30f;

	private EnemyHealth enemyHealth;
	private bool collided;


	void Update () {
		Collider[] hits = Physics.OverlapSphere (transform.position, radius, enemyMask);
		print (hits.Length);

		foreach (Collider c in hits) {

//			// if there have some Trigger
//			if (c.isTrigger) {
//				continue;
//			}

			enemyHealth = c.gameObject.GetComponent<EnemyHealth> ();
			collided = true;

		}

		if (collided) {
			enemyHealth.TakeDamage (damageCount);
			enabled = false;
		}
	}
} // class












