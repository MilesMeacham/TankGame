using UnityEngine;
using System.Collections;

public class HeartPickup : MonoBehaviour {

	public int healthToGive = 1;
	

	
	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			other.gameObject.GetComponent<CharacterHealth>().addHealth(healthToGive);
			gameObject.SetActive (false);
		}
		
		if (other.gameObject.layer == 8) 
		{
			GetComponent<Rigidbody2D> ().gravityScale = 0;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0);
		}
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.layer == 8) 
		{
			GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
		
	}
}
