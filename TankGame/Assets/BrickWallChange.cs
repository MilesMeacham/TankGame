using UnityEngine;
using System.Collections;

public class BrickWallChange : MonoBehaviour {


	public Sprite threeHitWall;
	public Sprite twoHitWall;
	public Sprite oneHitWall;

	private SpriteRenderer theSpriteRenderer;

	public CharacterHealth theCharacterHealth;
	// Use this for initialization
	void Start () {
		theCharacterHealth = GetComponent<CharacterHealth> ();
		theSpriteRenderer = GetComponent<SpriteRenderer> ();
		theSpriteRenderer.sprite = threeHitWall;
	}
	
	// Update is called once per frame
	void Update () {

		if (theCharacterHealth.health >= 3)
			theSpriteRenderer.sprite = threeHitWall;
		else if (theCharacterHealth.health < 3 && theCharacterHealth.health >= 2)
			theSpriteRenderer.sprite = twoHitWall;
		else
			theSpriteRenderer.sprite = oneHitWall;

	}
}
