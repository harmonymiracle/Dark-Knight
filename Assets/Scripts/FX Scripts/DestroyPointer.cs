using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour {

	private Transform player;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}
	
	
	void Update () {

		if (Vector3.Distance (player.transform.position, transform.position) <= 1.0f) {
			Destroy (gameObject);
		}
	}
} // class


















