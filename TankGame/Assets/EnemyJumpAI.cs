using UnityEngine;
using System.Collections;

public class EnemyJumpAI : MonoBehaviour {

	private CharacterJump theCharacterJump;

	public bool jumping;
	// Use this for initialization
	void Start () {
		theCharacterJump = GetComponentInParent<CharacterJump> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (jumping)
			theCharacterJump.Jumping ();

	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.layer == 8 && jumping == false) {
			StartCoroutine ("JumpCo");
		}

		if (Random.Range (0f , 10f) > 2f)
			StartCoroutine ("JumpCo");
	}

	IEnumerator JumpCo()
	{
		jumping = true;
		yield return new WaitForSeconds (0.8f);
		jumping = false;
	}

}
