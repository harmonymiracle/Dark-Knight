using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornadoMove : MonoBehaviour {


	public LayerMask enemyMask;

	public float radius = 1f;
	public float damageCount = 10f;
	public GameObject fireExplosion;


	private EnemyHealth enemyHealth;
	private bool collided;

	private float speed = 3f;

	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		transform.rotation = Quaternion.LookRotation (player.transform.forward);
	}
	
	void Update () {
		Move ();
		CheckForDamage ();

	}

	void Move () {
		transform.Translate (transform.forward * speed * Time.deltaTime);
	}

	void CheckForDamage () {
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
			Vector3 temp = transform.position;
			temp.y += 2f;
			Instantiate (fireExplosion, temp, Quaternion.identity);
			Destroy (gameObject);

		}
	}


} // class











