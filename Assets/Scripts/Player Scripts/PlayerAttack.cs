using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

	public Image fillWaitImage_1;
	public Image fillWaitImage_2;
	public Image fillWaitImage_3;
	public Image fillWaitImage_4;
	public Image fillWaitImage_5;
	public Image fillWaitImage_6;

	private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };

	private Animator anim;
	private bool canAttack = true;

	private PlayerMove playerMove;


	void Awake () {
		anim = GetComponent<Animator> ();
		playerMove = GetComponent <PlayerMove> ();

	}

	void Start () {
		
	}
	
	
	void Update () {
		if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo(0).IsName ("Stand")) {
			canAttack = true;
		} else {
			canAttack = false;
		}

		// CheckToFade ();
		CheckInput ();
	}



	void CheckInput () {

		// 0 - 6 mean 6 different skills
		if (anim.GetInteger ("Atk") == 0) {
			playerMove.FinishedMovement = false;

			if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand")) {
				playerMove.FinishedMovement = true;
			}
		}


	}


} // class

















