using UnityEngine;
using System.Collections;

public class CharacterJump : MonoBehaviour {
	

	public float jumpTime;
	public float jumpTimeCounter;
	public bool infiniteJump = false;

	private CharacterMotor theCharacterMotor;

	public bool grounded;
	public LayerMask whatIsGround;
	private Collider2D groundCheck;
	private GameObject groundCheckObj;

	public float hoverRefillSpeed = 1;

	public void Start () 
	{
		theCharacterMotor = GetComponent<CharacterMotor> ();
		jumpTimeCounter = jumpTime;

		groundCheckObj = transform.FindChild ("GroundCheck").gameObject;
		groundCheck = groundCheckObj.GetComponent<Collider2D> ();
	}

	void Update () 
	{
		HoverRefill ();
		GroundCheck ();
	}

	public void Jumping () {
		if (jumpTimeCounter > 0)
		{
			// call the VerticalMovement funtion on the character Motor
			theCharacterMotor.HoverJump();

			// limit jump time if "infiniteJump" == false
			if (!infiniteJump)
				jumpTimeCounter -= Time.deltaTime;
		}
	}

	void HoverRefill() {
		
		if (grounded && jumpTimeCounter < jumpTime)
			jumpTimeCounter += Time.deltaTime * hoverRefillSpeed;
		
		if (jumpTimeCounter > jumpTime)
			jumpTimeCounter = jumpTime;
	}

	void GroundCheck () {
		grounded = Physics2D.IsTouchingLayers (groundCheck, whatIsGround);
	}
}
