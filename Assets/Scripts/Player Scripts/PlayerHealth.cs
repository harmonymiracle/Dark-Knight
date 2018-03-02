using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


	public float health = 100f;

	private bool isShielded;
	public bool Shielded {
		get { return isShielded; }
		set { isShielded = value; }
	}

	private Animator anim;

	private Image healthImg;

	private string healthNameInHierarchy = "Health Icon";

	void Awake () {
		anim = GetComponent <Animator> ();
		healthImg = GameObject.Find (healthNameInHierarchy).GetComponent <Image> ();

	}

	void Start () {
		
	}
	
	

	public void TakeDamage (float amount) {
		if (!isShielded) {
			health -= amount;

			// 100f is the initial amount, maybe the number will heighter
			healthImg.fillAmount = health / 100f;

			print ("Player Tool Damage, left health: : " + health);
			if (health <= 0) {
//				anim.SetBool ("Death", true);
//
//				if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo (0).IsName ("Death") &&
//					anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.95f) {
//
////					Destroy (gameObject, 2f);
//				}
			}

		}
	}

	public void HealPlayer (float healAmount) {
		health += healAmount;

		if ( health> 100f) {
			health = 100f;
		}

		healthImg.fillAmount = health / 100f;

	}


} // class








