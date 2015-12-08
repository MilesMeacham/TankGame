using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount > 0)
		{
			Touch[] myTouches = Input.touches;
			for(int i = 0; i < Input.touchCount; i++)
			{
				if (myTouches[i].position.x > Screen.width/2)
				{
					theCharacterShoot.Shooting (playerShotStartPos);
				}
			}
		}
	

	}

	void FixedUpdate () {
		if (Input.touchCount > 0) 
		{
			Touch[] myTouches = Input.touches;
			for(int i = 0; i < Input.touchCount; i++)
			{
				if (myTouches[i].position.x < Screen.width / 2)
				{
					theCharacterJump.Jumping ();
				}
			}
		}

		theCharacterMotor.Movement ();

	}
}
