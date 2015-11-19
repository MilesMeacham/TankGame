using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {


	private CharacterShoot theCharacterShoot;
	private CharacterJump theCharacterJump;
	private CharacterMotor theCharacterMotor;

	public Transform playerShotStartPos;

	// Use this for initialization
	void Start () {
		theCharacterShoot = GetComponent<CharacterShoot> ();
		theCharacterJump = GetComponent<CharacterJump> ();
		theCharacterMotor = GetComponent<CharacterMotor> ();
	}
	

	void Update()
	{

		if (Input.GetKey (KeyCode.F))
			theCharacterShoot.Shooting (playerShotStartPos);
	}

	void FixedUpdate () 
	{
		
		if (Input.GetKey (KeyCode.Space) || (Input.GetKey (KeyCode.Mouse0)))
			theCharacterJump.Jumping ();

		theCharacterMotor.Movement ();

	}
}
