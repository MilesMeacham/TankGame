using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MyCharacterController {




	public float playerHealth = 20;
	public float playerDamage = 5;
	public float playerJumpForce = 0.4f;
	public float playerJumpTime = 2;
	public float playerMoveSpeed = 5;
	public float playerJumpTimeCounter;

	public Slider hoverSlider;
	
	public bool grounded;
	public LayerMask whatIsGround;
	
	private Collider2D playerCollider;
	private Collider2D groundCheck;
	
	private GameObject groundCheckObj;
	
	public GameManager gameManager;
	
	private Transform playerShotStartPos;
	//public GameObject bullets;
	//public ObjectPooler bulletPools;


	// Use this for initialization
	new void Start () {
		base.Start ();
		health = playerHealth;
		maxHealth = playerHealth;
		damage = playerDamage;
		jumpTime = playerJumpTime;
		moveSpeed = playerMoveSpeed;
//		jumpForce = playerJumpForce;

		playerJumpTimeCounter = playerJumpTime;
		jumpTimeCounter = playerJumpTimeCounter;

		rb = GetComponent<Rigidbody2D> ();


		playerShotStartPos = transform.FindChild ("ShotStartPos").gameObject.GetComponent<Transform> ();
		
		groundCheckObj = transform.FindChild ("GroundCheck").gameObject;
		groundCheck = groundCheckObj.GetComponent<Collider2D> ();

		playerCollider = GetComponent<Collider2D> ();
		
		jumpTimeCounter = jumpTime;
		
		hoverSlider = FindObjectOfType<Slider> ();
		
		hoverSlider.maxValue = jumpTime;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F))
			Shooting (playerShotStartPos);

		GroundCheck ();

		if (jumpTimeCounter < jumpTime)
			HoverRefill ();


	}
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Space) || (Input.GetKey (KeyCode.Mouse0)))
			Jumping (rb, playerJumpForce);

		Movement ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Deathzone")
			gameManager.RestartGame();
		
	}

	void GroundCheck () {
		grounded = Physics2D.IsTouchingLayers (groundCheck, whatIsGround);
	}

	void HoverRefill() {
		
		if (grounded && jumpTimeCounter < jumpTime)
			jumpTimeCounter += Time.deltaTime;
		
		if (jumpTimeCounter > jumpTime)
			jumpTimeCounter = jumpTime;
		
		hoverSlider.value = jumpTimeCounter;
	}

}
