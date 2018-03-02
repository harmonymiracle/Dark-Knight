using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControl : MonoBehaviour {

	private Transform playerTarget;
	private BossStateChecker bossStateChecker;
	private NavMeshAgent navAgent;
	private Animator anim;

	private bool finishedAttacking = true;
	private float currentAttackTime;
	private float waitAttackTime = 1f;

	void Awake () {
		playerTarget = GameObject.FindGameObjectWithTag ("Player").transform;
		bossStateChecker = GetComponent <BossStateChecker> ();
		navAgent = GetComponent <NavMeshAgent> ();
		anim = GetComponent <Animator> ();
	}
	
	void Start () {
		
	}
	
	
	void Update () {
		if (finishedAttacking) {
			 GetStateControl ();
		} else {
			anim.SetInteger ("Atk", 0);
			if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo(0).IsName ("Idle")) {
				finishedAttacking = true;
			}
		}
	}

	void GetStateControl () {
		
		if (bossStateChecker.BossState == BossState.DEATH) {
			navAgent.isStopped = true;

			anim.SetBool ("Death", true);
			Destroy (gameObject, 3f);
		} else {
			if (bossStateChecker.BossState == BossState.PAUSE) {
				navAgent.isStopped = false;
				anim.SetBool ("Run", true);

				navAgent.SetDestination (playerTarget.position);

			} else if (bossStateChecker.BossState == BossState.ATTACK) {
				anim.SetBool ("Run", false);
				Vector3 targetPos = new Vector3 (playerTarget.position.x, transform.position.y, playerTarget.position.z);

				transform.rotation = Quaternion.Slerp (transform.rotation,
					Quaternion.LookRotation (targetPos - transform.position), 5f * Time.deltaTime);

				if (currentAttackTime >= waitAttackTime) {
					int atkRange = Random.Range (1, 5);
					anim.SetInteger ("Atk", atkRange);

					currentAttackTime = 0f;
					finishedAttacking = false;

				} else {
					anim.SetInteger ("Atk", 0);
					currentAttackTime += Time.deltaTime;
				}

			} else {
				anim.SetBool ("Run", false);
				navAgent.isStopped = true;
			}
		}
	}



} // class










