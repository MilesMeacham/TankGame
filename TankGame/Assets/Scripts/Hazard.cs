using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

	public float damage = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
			gameObject.SetActive (false);

		
	}
}
