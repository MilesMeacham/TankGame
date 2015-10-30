using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 5;
	public float jumpForce = 10;	

	private Rigidbody2D playerRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;

	private Collider2D playerCollider;

	// Use this for initialization
	void Start () {

		playerRigidbody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		GroundCheck ();
		Jumping ();

	}

	void GroundCheck () {
		grounded = Physics2D.IsTouchingLayers (playerCollider, whatIsGround);
	}

	void Jumping () {

		if (grounded) {
			if ((Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown (KeyCode.Mouse0))) {
				playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpForce);
			}
		}
	}

	void Movement () {

		playerRigidbody.velocity = new Vector2 (moveSpeed, playerRigidbody.velocity.y);
		


	}
}
