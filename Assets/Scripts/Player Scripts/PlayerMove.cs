using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private Animator anim;

	// use for move and Collision check
	private CharacterController charController;
	private CollisionFlags collisionFlags = CollisionFlags.None;

	private float moveSpeed = 5f;
	private bool canMove = false;
	private bool finishedMovement = true;

	// the mouse click point
	private Vector3 targetPos = Vector3.zero;

	// the calculated move Vector3
	private Vector3 playerMove = Vector3.zero;

	// check if or not have enough close to the destination
	private float playerToPointDistance;

	// implement the gravity;
	private float gravity = 9.8f;
	private float height;

	void Awake () {
		anim = GetComponent <Animator> ();
		charController = GetComponent <CharacterController> ();

	}

	
	void Update () {
		CalculateHeight ();
		CheckIfFinishedMovement ();
	}

	bool IsGrounded () {
		return collisionFlags == CollisionFlags.CollidedBelow;
	}

	// implement the gravity, height as a argument in playerMove 
	void CalculateHeight () {
		if (IsGrounded ()) {
			height = 0f;
		} else {
			height -= gravity * Time.deltaTime;
		}
	}

	void CheckIfFinishedMovement () {
		
		if (!finishedMovement) {

			// if the movement will be done
			// IsInTransition(int layer) in a specified layer, like base layer
			// GetCurrentAnimatorStateInfo (int layer) return the Current state info
			// normalized time of animation is represented from 0 to1
			// 0 mean beginning, .5 mean middle, 1 mean end
			if (!anim.IsInTransition(0) && !anim.GetCurrentAnimatorStateInfo (0).IsName ("Stand")
				&& anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f) {
				finishedMovement = true;
			}

		} else {


			// Extract this from MovePlayer for implement the gravity
			MovePlayer ();
			playerMove.y = height * Time.deltaTime;
			collisionFlags = charController.Move (playerMove);

		}
	}

	void MovePlayer () {

		// use raycast get the click point in 3D world
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitinfo;

			if (Physics.Raycast (ray,out  hitinfo)) {
				if (hitinfo.collider is TerrainCollider) {

					playerToPointDistance = Vector3.Distance (transform.position, hitinfo.point);

					if (playerToPointDistance >= 1f) {
						canMove = true;
						targetPos = hitinfo.point;
					}
				}
			}
		}



		if (canMove) {
			anim.SetFloat ("Walk", 1.0f);

			Vector3 targetTemp = new Vector3 (targetPos.x, transform.position.y, targetPos.z);

			transform.rotation = Quaternion.Slerp (transform.rotation, 
				Quaternion.LookRotation (targetPos - transform.position),
				60f * Time.deltaTime
				//Quaternion.FromToRotation (transform.position, targetPos),
			);

			playerMove = transform.forward * moveSpeed * Time.deltaTime;

			if (Vector3.Distance (transform.position, targetPos) <= 1f) {
				canMove = false;

			}

		} else {
			playerMove.Set (0f, 0f, 0f);
			anim.SetFloat ("Walk", 0f);
		}


	}

} // class


















