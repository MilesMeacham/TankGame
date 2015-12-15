using UnityEngine;
using System.Collections;

public class BrickWallChange : MonoBehaviour {


	public Sprite threeHitWall;
	public Sprite twoHitWall;
	public Sprite oneHitWall;

	public float currentHealth;
	public float previousHealth;

	private SpriteRenderer theSpriteRenderer;

	public CharacterHealth theCharacterHealth;

	private AudioSource brickWallBreak;
	// Use this for initialization
	void Start () {
		brickWallBreak = GameObject.Find ("Player").GetComponent<CharacterPlayer> ().brickWallBreak;
		theCharacterHealth = GetComponent<CharacterHealth> ();
		theSpriteRenderer = GetComponent<SpriteRenderer> ();
		theSpriteRenderer.sprite = threeHitWall;
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = theCharacterHealth.health;

		if (currentHealth >= 3)
			theSpriteRenderer.sprite = threeHitWall;
		else if (currentHealth < 3 && theCharacterHealth.health >= 2)
			theSpriteRenderer.sprite = twoHitWall;
		else
			theSpriteRenderer.sprite = oneHitWall;

		if(previousHealth > currentHealth)
			brickWallBreak.Play ();

		previousHealth = currentHealth;
	}
}
