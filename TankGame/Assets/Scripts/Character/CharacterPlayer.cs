using UnityEngine;
using System.Collections;

public class CharacterPlayer : MonoBehaviour {

	public CharacterHealth theCharacterHealth;
	private CharacterMotor theCharacterMotor;
	
	private GameObject thePlayerDesiredPoint;
	
	public bool adjustedSpeed;

	
	// Use this for initialization
	public void Start () 
	{

		thePlayerDesiredPoint = GameObject.Find ("PlayerDesiredPoint");
		theCharacterMotor = GetComponent<CharacterMotor> ();
		theCharacterHealth = GetComponent<CharacterHealth> ();
		
	}
	
	void FixedUpdate () 
	{

		if (transform.position.x < (thePlayerDesiredPoint.transform.position.x - 0.5f) && !adjustedSpeed)
		{
			theCharacterMotor.adjustedSpeed = 2;
			adjustedSpeed = true;
		}
		else if (transform.position.x > (thePlayerDesiredPoint.transform.position.x + 0.5f) && !adjustedSpeed)
		{
			theCharacterMotor.adjustedSpeed = -2;
			adjustedSpeed = true;
		}
		else
		{
			theCharacterMotor.adjustedSpeed = 0;
			adjustedSpeed = false;
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (!GetComponent<CharacterHealth>().invincible) {

			if (other.gameObject.tag == "EnemyBullet")
			{
				theCharacterHealth.removeHealth (other.GetComponent<BulletMovement> ().bulletDamage);
				theCharacterHealth.Invincibility();
			}


			if (other.gameObject.tag == "Hazard")
			{
				theCharacterHealth.removeHealth (other.GetComponent<Hazard> ().damage);
				theCharacterHealth.Invincibility();
			}

			if (other.gameObject.tag == "Enemy")
			{
				theCharacterHealth.removeHealth (1);
				theCharacterHealth.Invincibility();
			}


		}
	}


	
	
}
