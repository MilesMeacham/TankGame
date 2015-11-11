using UnityEngine;
using System.Collections;

public class EnemyFlying : EnemyBaseClass {
	


	new void Awake () {
		enemyHealth = 5;

	}

	// Use this for initialization
	new void Start () {
		base.Start();
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 0;
		FlyingFormation ();

	

	}
	
	new void Update () {
		base.Update ();
		Movement ();
		VerticalMovement ();
	}


	void FlyingFormation(){

		StartCoroutine ("FlyingFormationCo");

	}

	IEnumerator FlyingFormationCo(){


		jumpForce = 0;
		moveSpeed = 0;
		yield return new WaitForSeconds (2f);
		jumpForce = 2;
		moveSpeed = 5;
		yield return new WaitForSeconds (1f);
		jumpForce = 0;
		moveSpeed = 7;
		yield return new WaitForSeconds (1f);
		jumpForce = -2;
		moveSpeed = 5;
		yield return new WaitForSeconds (1f);
		jumpForce = 0;
		moveSpeed = -2;

		yield return new WaitForSeconds (3f);
		gameObject.SetActive (false);
	

	}
}
