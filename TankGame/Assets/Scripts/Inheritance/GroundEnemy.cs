using UnityEngine;
using System.Collections;

public class GroundEnemy : EnemyBaseClass {

	public float desiredDistanceFromPlayer = 10;
	public float actualDistanceFromPlayer;
	
	public int enemyMoveSpeed = 5;
	
	// Use this for initialization
	new void Start () {
		base.Start();
		moveSpeed = enemyMoveSpeed;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	new void Update () {
		base.Update ();
		actualDistanceFromPlayer = transform.position.x - player.transform.position.x;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		EnemyMovement ();

		
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


}