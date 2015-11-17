using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 5;
	public float jumpForce = 0.4f;
	public float jumpTime = 2f;
	private float jumpTimeCounter;


	public Slider hoverSlider;

	private Rigidbody2D playerRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;

//	private Collider2D playerCollider;
	private Collider2D groundCheck;

	private GameObject groundCheckObj;

	public GameManager gameManager;

	private Transform shotStartPos;
	public GameObject bullets;
	public ObjectPooler bulletPools;

	// Use this for initialization
	void Start () {

		shotStartPos = transform.FindChild ("ShotStartPos").gameObject.GetComponent<Transform> ();

		groundCheckObj = transform.FindChild ("GroundCheck").gameObject;
		groundCheck = groundCheckObj.GetComponent<Collider2D> ();

		playerRigidbody = GetComponent<Rigidbody2D> ();
//		playerCollider = GetComponent<Collider2D> ();

		jumpTimeCounter = jumpTime;

		hoverSlider = FindObjectOfType<Slider> ();

		hoverSlider.maxValue = jumpTime;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Movement ();
		GroundCheck ();

		if (jumpTimeCounter < jumpTime)
			HoverRefill ();

		if (Input.GetKey (KeyCode.Space) || (Input.GetKey (KeyCode.Mouse0)))
			Jumping ();
			
		if (Input.GetKeyDown (KeyCode.F) || Input.GetKey (KeyCode.Mouse1))
			Shooting ();

	}

	void Shooting () {
		bullets = bulletPools.GetPooledObject ();
		bullets.transform.position = shotStartPos.transform.position;
		bullets.transform.rotation = shotStartPos.transform.rotation;
		bullets.SetActive (true);
	}


	void GroundCheck () {
		grounded = Physics2D.IsTouchingLayers (groundCheck, whatIsGround);
	}

	void Jumping () {
		if (jumpTimeCounter > 0)
		{
			playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, playerRigidbody.velocity.y + jumpForce);
			jumpTimeCounter -= Time.deltaTime;
		}
	}

	void HoverRefill() {

		if (grounded && jumpTimeCounter < jumpTime)
			jumpTimeCounter += Time.deltaTime;

		if (jumpTimeCounter > jumpTime)
			jumpTimeCounter = jumpTime;

		hoverSlider.value = jumpTimeCounter;
	}

	void Movement () {
		playerRigidbody.velocity = new Vector2 (moveSpeed, playerRigidbody.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Deathzone")
			gameManager.RestartGame();

	}
}
