using UnityEngine;
using System.Collections;

public class GroundEnemy : EnemyBaseClass {

	public float desiredDistanceFromPlayer = 10;
	public float actualDistanceFromPlayer;
	
	public int enemyMoveSpeed = 5;

	public bool timedShot;
	private Transform enemyShotStartPos;
	
	// Use this for initialization
	new void Start () {
		base.Start();
		moveSpeed = enemyMoveSpeed;
		rb = GetComponent<Rigidbody2D> ();

		enemyShotStartPos = transform.FindChild ("ShotStartPos").gameObject.GetComponent<Transform> ();
	}
	
	new void Update () {
		base.Update ();
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
	
		Movement ();
		
		if (actualDistanceFromPlayer < desiredDistanceFromPlayer)
			moveSpeed = 8;
		else if (actualDistanceFromPlayer > desiredDistanceFromPlayer + 1)
			moveSpeed = 3;
		else
			moveSpeed = 5;


	}

	IEnumerator TimedShotCo(){

		timedShot = true;
		yield return new WaitForSeconds (2f);
		Shooting(enemyShotStartPos);
		timedShot = false;
	}

}