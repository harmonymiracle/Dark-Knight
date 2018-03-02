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


	
	void Update () {
		if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo(0).IsName ("Stand")) {
			canAttack = true;
		} else {
			canAttack = false;
		}

		CheckToFade ();
		CheckInput ();
	}



	void CheckInput () {

		// 0 - 6 mean 6 different skills
		if (anim.GetInteger ("Atk") == 0) {
			playerMove.FinishedMovement = false;

			if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Stand")) {
				playerMove.FinishedMovement = true;
			}
		}

		// this code is very ugly, should be refactor
		if (Input.GetKeyDown (KeyCode.Alpha1)) {

			if (playerMove.FinishedMovement && fadeImages [0] != 1 && canAttack) {
				fadeImages [0] = 1;
				anim.SetInteger ("Atk", 1);
				// if attack, stay here first
				playerMove.TargetPosition = transform.position;
				RemoveCursorPoint ();

			} 
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {


			if (playerMove.FinishedMovement && fadeImages [1] != 1 && canAttack) {
				fadeImages [1] = 1;
				anim.SetInteger ("Atk", 2);
				// if attack, stay here first
				playerMove.TargetPosition = transform.position;
				RemoveCursorPoint ();


			} 
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {


			if (playerMove.FinishedMovement && fadeImages [2] != 1 && canAttack) {
				fadeImages [2] = 1;
				anim.SetInteger ("Atk", 3);

				// if attack, stay here first
				playerMove.TargetPosition = transform.position;
				RemoveCursorPoint ();


			} 
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {


			if (playerMove.FinishedMovement && fadeImages [3] != 1 && canAttack) {
				fadeImages [3] = 1;
				anim.SetInteger ("Atk", 4);

				// if attack, stay here first
				playerMove.TargetPosition = transform.position;
				RemoveCursorPoint ();


			} 
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {


			if (playerMove.FinishedMovement && fadeImages [4] != 1 && canAttack) {
				fadeImages [4] = 1;
				anim.SetInteger ("Atk", 5);

				// if attack, stay here first
				playerMove.TargetPosition = transform.position;
				RemoveCursorPoint ();


			} 
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {


			if (playerMove.FinishedMovement && fadeImages [5] != 1 && canAttack) {
				fadeImages [5] = 1;
				anim.SetInteger ("Atk", 6);

				// if attack, stay here first
				playerMove.TargetPosition = transform.position;
				RemoveCursorPoint ();


			} 
		} else {
			anim.SetInteger ("Atk", 0);
		}

		if (Input.GetKey(KeyCode.Space)) {
			Vector3 targetPos = Vector3.zero;

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray,out hit)) {
				targetPos = new Vector3 (hit.point.x, transform.position.y, hit.point.z);

			}

			// the difference between LookRotation and FromToRotation:
			// LookRotation: the Quaternion that game object need to look target 
			// FromToRotation: the Quaternion that from direction need tp parallel the to direction
			// there are some subtle difference

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (targetPos - transform.position), 15f * Time.deltaTime);

		}

	}

	void CheckToFade () {
		if (fadeImages [0] == 1) {
			if (FadeAndWait (fillWaitImage_1, 1f)) {
				fadeImages [0] = 0;
			}
		}

		if (fadeImages [1] == 1) {
			if (FadeAndWait (fillWaitImage_2, 0.7f)) {
				fadeImages [1] = 0;
			}
		}

		if (fadeImages [2] == 1) {
			if (FadeAndWait (fillWaitImage_3, 0.1f)) {
				fadeImages [2] = 0;
			}
		}

		if (fadeImages [3] == 1) {
			if (FadeAndWait (fillWaitImage_4, 0.2f)) {
				fadeImages [3] = 0;
			}
		}

		if (fadeImages [4] == 1) {
			if (FadeAndWait (fillWaitImage_5, 0.3f)) {
				fadeImages [4] = 0;
			}
		}

		if (fadeImages [5] == 1) {
			if (FadeAndWait (fillWaitImage_6, 1f)) {
				fadeImages [5] = 0;
			}
		}
	}

	bool FadeAndWait (Image fadeImg, float fadeTime) {
		bool faded = false;

		if (fadeImg == null) {
			return faded;
		}

		if (!fadeImg.gameObject.activeInHierarchy) {
			fadeImg.gameObject.SetActive (true);
			fadeImg.fillAmount = 1f;
		}

		fadeImg.fillAmount -= fadeTime * Time.deltaTime;

		if (fadeImg.fillAmount <= 0.0f) {
			fadeImg.gameObject.SetActive (false);
			faded = true;
		}

		return faded;
	}

	void RemoveCursorPoint () {
		GameObject cursorPoint = GameObject.FindGameObjectWithTag ("Cursor");
		if (cursorPoint) {
			Destroy (cursorPoint);
		}
	}

} // class

















