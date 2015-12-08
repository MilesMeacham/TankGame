﻿using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float bulletMoveSpeed = 20;
	public float bulletLifeSpan = 2f;
	public float bulletDamage;

	private int bulletCollision;
	public int collisionLimit = 2;


	void Start () {
		//StartCoroutine ("BulletDestroyCo");


	}

	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Transform> ().transform.Translate (Vector2.right * bulletMoveSpeed * Time.deltaTime);


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
			bulletCollision++;
		//if(other.gameObject.tag == "Deathzone" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
		if (bulletCollision > collisionLimit) 
		{
			gameObject.SetActive (false);
			bulletCollision = 0;
		}

		if (other.gameObject.tag == "Deathzone")
			gameObject.SetActive (false);

		if (other.gameObject.tag == "Destructable") 
		{
			gameObject.SetActive (false);
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{

		if (other.gameObject.tag == "PlayableArea")
		{
			gameObject.SetActive (false);
			bulletCollision = 0;
		}

	}

	public IEnumerator BulletDestroyCo()
	{

		yield return new WaitForSeconds (bulletLifeSpan);
		bulletCollision = 0;
		gameObject.SetActive (false);

	}

}
