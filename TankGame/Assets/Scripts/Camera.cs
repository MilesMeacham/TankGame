using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public PlayerController player;

	private Vector3 lastPosition;
	private float distanceToMove;
	//private float distanceUp;
	//private float distanceToMoveUp;

	private Rigidbody2D cameraRigidbody;

	public int moveSpeed = 5;

	// Use this for initialization
	void Start () {
	
		cameraRigidbody = GetComponent<Rigidbody2D> ();
		cameraRigidbody.gravityScale = 0;

		player = FindObjectOfType<PlayerController> ();

		lastPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CameraMovement ();

		//distanceToMove = player.transform.position.x - lastPosition.x;
		//distanceToMoveUp = player.transform.position.y - lastPosition.y;
		//distanceUp = player.transform.position.y;

		/*
		if (distanceUp > 2) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (distanceToMoveUp / 2), transform.position.z);
		} else if (distanceUp < 2) {
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		}
		*/

		//transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
	
		//lastPosition = player.transform.position;

	}

	void CameraMovement()
	{
		cameraRigidbody.velocity = new Vector2 (moveSpeed, 0);
	}
}
