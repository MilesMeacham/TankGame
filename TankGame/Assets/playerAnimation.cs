using UnityEngine;
using System.Collections;

public class playerAnimation : MonoBehaviour {

	private Animator theAnimator;

	public CharacterShoot theCharacterShoot;

	// Use this for initialization
	void Start () {
		theAnimator = GetComponent<Animator> ();

		theCharacterShoot = GetComponentInParent<CharacterShoot> ();


	}
	
	// Update is called once per frame
	void Update () {

		theAnimator.SetBool ("Shot", theCharacterShoot.shotFired);
		theCharacterShoot.shotFired = false;
	}
}
