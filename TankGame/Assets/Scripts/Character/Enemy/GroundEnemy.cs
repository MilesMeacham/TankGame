using UnityEngine;
using System.Collections;

public class GroundEnemy : EnemyBaseClass {

	public float desiredDistanceFromPlayer = 10;
	public float actualDistanceFromPlayer;
	
	public CharacterMotor theCharacterMotor;
	public CharacterShoot theCharacterShoot;

	public bool timedShot;
	private Transform enemyShotStartPos;
	
	// Use this for initialization
	new void Start () {
		base.Start();

		theCharacterMotor = GetComponent<CharacterMotor> ();
		theCharacterShoot = GetComponent<CharacterShoot> ();

		enemyShotStartPos = transform.FindChild ("ShotStartPos").gameObject.GetComponent<Transform> ();
	}
	
	void Update () {

		actualDistanceFromPlayer = transform.position.x - player.transform.position.x;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		EnemyMovement ();

		if (!timedShot)
			StartCoroutine("TimedShotCo");
		
	}
	
	void EnemyMovement()
	{
	
		theCharacterMotor.Movement ();
		
		if (actualDistanceFromPlayer < desiredDistanceFromPlayer)
			theCharacterMotor.moveSpeed = 8;
		else if (actualDistanceFromPlayer > desiredDistanceFromPlayer + 1)
			theCharacterMotor.moveSpeed = 3;
		else
			theCharacterMotor.moveSpeed = 5;


	}

	IEnumerator TimedShotCo(){

		timedShot = true;
		yield return new WaitForSeconds (2f);
		theCharacterShoot.Shooting(enemyShotStartPos);
		timedShot = false;
	}

}