using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float followHeight = 8f;
	public float followDistance = 6f;

	private Transform player; // target

	private float targetHeight;
	private float currentHeight;
	private float currentRotation;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	
	void Update () {

	}

	// usually place the camera code the LateUpdate()
	void LateUpdate () {

		// get the target height
		targetHeight = player.position.y + followHeight;
		// from the start height lerp to target height
		currentHeight = Mathf.Lerp (transform.position.y, targetHeight, 0.9f * Time.deltaTime);

		// get the value of transform rotation by y axis
		currentRotation = transform.eulerAngles.y;

		// construct a Quaternion, get the actual backside of player, then get the point in 2D
		Quaternion euler = Quaternion.Euler (0f, currentRotation, 0f);
		Vector3 targetPos = player.position - (euler * Vector3.forward) * followDistance;

		// change the point's height, get the point in 3D
		targetPos.y = currentHeight;

		transform.position = targetPos;
		transform.LookAt (player);


	}

} // class















