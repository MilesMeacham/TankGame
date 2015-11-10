using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Player player;
	
	public float desiredDistanceFromPlayer = 10;
	public float actualDistanceFromPlayer;

	private Rigidbody2D enemyRb;
	
	public int moveSpeed = 5;
	
	// Use this for initialization
	void Start () {
		
		enemyRb = GetComponent<Rigidbody2D> ();
		
		player = FindObjectOfType<Player> ();

	}

	void Update () {

		actualDistanceFromPlayer = transform.position.x - player.transform.position.x;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		EnemyMovement ();
		
	}
	
	void EnemyMovement()
	{
		enemyRb.velocity = new Vector2 (moveSpeed, enemyRb.velocity.y);

		if (actualDistanceFromPlayer < desiredDistanceFromPlayer)
			moveSpeed = 8;
		else if (actualDistanceFromPlayer > desiredDistanceFromPlayer + 1)
			moveSpeed = 3;
		else
			moveSpeed = 5;
	}


}