using UnityEngine;
using System.Collections;

public class playerAnimation : MonoBehaviour {

	private Animator theAnimator;

	public CharacterShoot theCharacterShoot;

	public CharacterJump theCharacterJump;

	public GameObject hoverFire;

	public Rigidbody2D playerRB;

	public bool activated;
	// Use this for initialization
	void Start () {
		theAnimator = GetComponent<Animator> ();

		theCharacterShoot = GetComponentInParent<CharacterShoot> ();

		theCharacterJump = GetComponentInParent<CharacterJump> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (!theCharacterJump.grounded && !activated && !theCharacterJump.groundedEnemy) 
		{
			activated = true;
			hoverFire.SetActive (true);


		}

		if (playerRB.velocity.y <= 0) 
		{
			activated = false;
			hoverFire.SetActive (false);

		}

		theAnimator.SetBool ("Shot", theCharacterShoot.shotFired);
		theCharacterShoot.shotFired = false;
	}
}
