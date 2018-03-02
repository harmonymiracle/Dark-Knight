using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float timer = 1.5f;
	
	void Start () {
		StartCoroutine (DestroyEffect ());
	}
	
	IEnumerator DestroyEffect () {
		yield return new WaitForSeconds (timer);
		Destroy (gameObject);
	}



}
