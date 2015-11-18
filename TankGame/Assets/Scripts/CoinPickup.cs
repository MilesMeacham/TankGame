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

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			theScoreManager.additionalScore += scoreToGive;
			Destroy(gameObject);
		}
		
	}
}
