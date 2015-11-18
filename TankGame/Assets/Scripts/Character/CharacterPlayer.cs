using UnityEngine;
using System.Collections;

public class CharacterPlayer : MonoBehaviour {

	public CharacterHealth theCharacterHealth;
	

	
	// Use this for initialization
	public void Start () {
		
		theCharacterHealth = GetComponent<CharacterHealth> ();
		
	}
	
	void FixedUpdate () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "EnemyBullet")
			theCharacterHealth.removeHealth(other.GetComponent<BulletMovement>().bulletDamage);
		
		
	}
	
	
}
