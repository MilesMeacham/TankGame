using UnityEngine;
using System.Collections;

public class BarbedWire : MonoBehaviour {

	private CharacterMotor theCharacterMotor;
	private CharacterMotor myCharacterMotor;
	public bool follow;
	public bool speedSaved;

	public float tempSpeed;
	// Use this for initialization
	void Start () {
		theCharacterMotor = GameObject.Find ("Player").GetComponent<CharacterMotor> ();
		myCharacterMotor = GetComponent<CharacterMotor> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		myCharacterMotor.Movement();
		FollowPlayer ();

	}

	void FollowPlayer ()
	{
		if (follow) 
		{
			if(!speedSaved)
			{
				tempSpeed = theCharacterMotor.moveSpeed;
				speedSaved = true;

				theCharacterMotor.moveSpeed = (theCharacterMotor.moveSpeed / 2);
				myCharacterMotor.moveSpeed = (theCharacterMotor.moveSpeed) - 1;
				if (myCharacterMotor.moveSpeed < 0)
					myCharacterMotor.moveSpeed = 0;
			}







		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "Player") 
		{

			follow = true;
		}


	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			follow = false;

			theCharacterMotor.moveSpeed = tempSpeed;
			myCharacterMotor.moveSpeed = 0;
			speedSaved = false;
		}
		
		
	}

}
