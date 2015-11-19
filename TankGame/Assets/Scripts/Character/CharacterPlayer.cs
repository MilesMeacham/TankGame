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
			theCharacterMotor.moveSpeed = 6;
			adjustedSpeed = true;
		}
		else if (transform.position.x > (thePlayerDesiredPoint.transform.position.x + 0.5f) && !adjustedSpeed)
		{
			theCharacterMotor.moveSpeed = 4;
			adjustedSpeed = true;
		}
		else
		{
			theCharacterMotor.moveSpeed = 5;
			adjustedSpeed = false;
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "EnemyBullet")
			theCharacterHealth.removeHealth(other.GetComponent<BulletMovement>().bulletDamage);
		
		
	}
	
	
}
