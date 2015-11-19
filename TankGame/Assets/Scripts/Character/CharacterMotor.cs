using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {
	
	public float moveSpeed;
	public float jumpForce;
	public float verticalMoveSpeed;

	public Rigidbody2D rb;

	private CharacterHealth theCharacterHealth;
	private GameManager theGameManager;

	void Start (){

		rb = GetComponent<Rigidbody2D>();
		theCharacterHealth = GetComponent<CharacterHealth> ();
		theGameManager = FindObjectOfType<GameManager> ();
	}

	//public void Movement (Rigidbody2D rb, float moveSpeed) {
	public void Movement ()
	{
		rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
	}

	public void VerticalMovement ()
	{
		rb.velocity = new Vector2 (rb.velocity.x, verticalMoveSpeed);
	}

	public void HoverJump ()
	{
		rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y + jumpForce);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "DeathZoneDontLeave" && this.gameObject.tag != "Player") 
		{
			theCharacterHealth.destroyObject ();
		} 
		else if (other.gameObject.name == "DeathZoneDontLeave" && this.gameObject.tag == "Player")
		{
			theGameManager.RestartGame ();
		}
	}
	


}
