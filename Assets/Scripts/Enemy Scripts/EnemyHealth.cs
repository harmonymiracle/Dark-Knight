using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float health = 100f;

	public Image healthImg;


	public void TakeDamage (float amount) {
		health -= amount;

		// 100f is the initial health.
		healthImg.fillAmount = health / 100f;

		print ("enemy left health: " + health);

		if (health <= 0) {
			
		}
	}


} // class









