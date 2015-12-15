using UnityEngine;
using System.Collections;

public class EnemyBaseClass : MonoBehaviour {

	public CharacterHealth theCharacterHealth;

	protected GameObject player;

	// Use this for initialization
	public void Start () {

		theCharacterHealth = GetComponent<CharacterHealth> ();
		player = GameObject.FindGameObjectWithTag ("Player");	

	}

	void FixedUpdate () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "PlayerBullet")
			theCharacterHealth.removeHealth(other.GetComponent<BulletMovement>().bulletDamage);

		if (other.gameObject.tag == "Deathzone")
			gameObject.SetActive (false);

	}
	

}
