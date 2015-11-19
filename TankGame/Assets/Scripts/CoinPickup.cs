using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () 
	{
		theScoreManager = FindObjectOfType<ScoreManager> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			theScoreManager.additionalScore += scoreToGive;
			Destroy(gameObject);
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
