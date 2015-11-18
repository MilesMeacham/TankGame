using UnityEngine;
using System.Collections;

public class EnemyFlying : EnemyBaseClass {
	
	public CharacterMotor theCharacterMotor;


	// Use this for initialization
	new void Start () {
		base.Start ();
		FlyingFormation ();
		GetComponent<Rigidbody2D> ().gravityScale = 0;
	}
	
	void FixedUpdate () {
		theCharacterMotor.Movement ();
		theCharacterMotor.VerticalMovement ();
	}


	void FlyingFormation(){

		StartCoroutine ("FlyingFormationCo");

	}

	IEnumerator FlyingFormationCo(){


		theCharacterMotor.verticalMoveSpeed = 0;
		theCharacterMotor.moveSpeed = 0;
		yield return new WaitForSeconds (2f);
		theCharacterMotor.verticalMoveSpeed = 2;
		theCharacterMotor.moveSpeed = 5;
		yield return new WaitForSeconds (1f);
		theCharacterMotor.verticalMoveSpeed = 0;
		theCharacterMotor.moveSpeed = 7;
		yield return new WaitForSeconds (1f);
		theCharacterMotor.verticalMoveSpeed = -2;
		theCharacterMotor.moveSpeed = 5;
		yield return new WaitForSeconds (1f);
		theCharacterMotor.verticalMoveSpeed = 0;
		theCharacterMotor.moveSpeed = -2;

		yield return new WaitForSeconds (3f);
		gameObject.SetActive (false);
	

	}

}
