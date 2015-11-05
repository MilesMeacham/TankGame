using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 5;
	public float jumpForce = 10;
	public float jumpTime = 2f;
	private float jumpTimeCounter;
	public float hoverForce = 0.2f;

	public Slider hoverSlider;

	private Rigidbody2D playerRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;

	private Collider2D playerCollider;
	private Collider2D groundCheck;

	private GameObject groundCheckObj;

	public GameManager gameManager;

	public

	// Use this for initialization
	void Start () {

		groundCheckObj = transform.FindChild ("GroundCheck").gameObject;
		groundCheck = groundCheckObj.GetComponent<Collider2D> ();

		playerRigidbody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<Collider2D> ();

		jumpTimeCounter = jumpTime;

		hoverSlider = FindObjectOfType<Slider> ();

		hoverSlider.maxValue = jumpTime;
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
			if (Input.GetKeyDown (KeyCode.Space) || (Input.GetKeyDown (KeyCode.Mouse0))) {
				playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, hoverForce);
			}
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Mouse0))
	    {
			if (jumpTimeCounter > 0)
			{
				playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, playerRigidbody.velocity.y + hoverForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (grounded && jumpTimeCounter < jumpTime)
			jumpTimeCounter += Time.deltaTime;

		if (jumpTimeCounter > jumpTime)
			jumpTimeCounter = jumpTime;

		hoverSlider.value = jumpTimeCounter;
	}

	void Movement () {

		playerRigidbody.velocity = new Vector2 (moveSpeed, playerRigidbody.velocity.y);
		


	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Deathzone")
			gameManager.RestartGame();

	}
}
