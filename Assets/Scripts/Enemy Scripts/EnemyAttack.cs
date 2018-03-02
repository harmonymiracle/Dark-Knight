using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


	public float damageAmount = 10f;

	private Transform playerTarget;
	private Animator anim;
	private PlayerHealth playerHealth;

	private bool finishedAttack = true;
	private float damageDistance = 2f;


	void Awake () {
		playerTarget = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent <Animator> ();

		playerHealth = playerTarget.GetComponent <PlayerHealth> ();
	}

	
	void Update () {
		if (finishedAttack) {
			if (playerTarget) {
				DealDamage (CheckIfAttacking ());
			}

		} else {

			// IsInTransition mean that if the anim in the state transition
			if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo(0).IsName ("Idle")) {
				finishedAttack = true;
			}
		}
	}

	bool CheckIfAttacking () {
		bool isAttacking = false;

		if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo(0).IsName ("Atk1") ||
			anim.GetCurrentAnimatorStateInfo (0).IsName ("Atk2")) {

			if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.5f) {
				isAttacking = true;
				finishedAttack = true;
			}


		}
		return isAttacking;
	}

	void DealDamage (bool isAttacking) {
		if (isAttacking) {
			if (Vector3.Distance (transform.position, playerTarget.position) <= damageDistance) {
				playerHealth.TakeDamage (damageAmount);
			}
		}
	}


} // class 












