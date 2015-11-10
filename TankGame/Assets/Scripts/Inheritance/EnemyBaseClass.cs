using UnityEngine;
using System.Collections;

public class EnemyBaseClass : MyCharacterController {

	public Player player;

	public float enemyHealth = 20;
	public float enemyDamage = 5;
	public float enemyJumpForce = 0.8f;
	public float enemyJumpTime = 100;
	public float enemyJumpTimeCounter;

	
	// Use this for initialization
	protected new void Start () {
		base.Start ();
		health = enemyHealth;
		maxHealth = enemyHealth;
		damage = enemyDamage;
		jumpTime = enemyJumpTime;

		//jumpForce = enemyJumpForce;
		player = FindObjectOfType<Player> ();
		
		enemyJumpTimeCounter = enemyJumpTime;
		jumpTimeCounter = enemyJumpTimeCounter;

		
	}

	void FixedUpdate () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Bullet"){

			removeHealth(player.playerDamage);
		}
	}

}
