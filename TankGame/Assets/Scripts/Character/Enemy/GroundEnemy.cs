using UnityEngine;
using System.Collections;

public class GroundEnemy : EnemyBaseClass {

	public float desiredDistanceFromPlayer = 10;
	public float actualDistanceFromPlayer;
	
	public CharacterMotor theCharacterMotor;
	public CharacterShoot theCharacterShoot;

	public MyCamera theCamera;

	public bool timedShot;
	private Transform enemyShotStartPos;

	public GameObject thePlayer;
	
	// Use this for initialization
	new void Start () {
		base.Start();

		theCamera = FindObjectOfType<MyCamera> ();
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		theCharacterMotor = GetComponent<CharacterMotor> ();
		theCharacterShoot = GetComponent<CharacterShoot> ();

		enemyShotStartPos = transform.FindChild ("ShotStartPos").gameObject.GetComponent<Transform> ();


	}
	
	void Update () {

		actualDistanceFromPlayer = transform.position.x - thePlayer.transform.position.x;
		
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
		
		if (actualDistanceFromPlayer < (desiredDistanceFromPlayer - 1))
			theCharacterMotor.moveSpeed = theCamera.moveSpeed + 3;
		else if (actualDistanceFromPlayer > desiredDistanceFromPlayer + 3)
			theCharacterMotor.moveSpeed = -3;
		else if (actualDistanceFromPlayer > desiredDistanceFromPlayer)
			theCharacterMotor.moveSpeed = theCamera.moveSpeed - 2;
		else
			theCharacterMotor.moveSpeed = theCamera.moveSpeed;


	}

	IEnumerator TimedShotCo(){

		timedShot = true;
		yield return new WaitForSeconds (2f);
		theCharacterShoot.Shooting(enemyShotStartPos);
		timedShot = false;
	}

}