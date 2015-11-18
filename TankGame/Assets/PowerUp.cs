using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public float multiplyBy;

	public bool damage;
	public bool shotSpeed;
	public bool shotRate;
	public bool moveSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if(damage)
				other.gameObject.GetComponent<CharacterShoot>().damage += multiplyBy;

			if(shotSpeed)
				other.gameObject.GetComponent<CharacterShoot>().moveSpeed += multiplyBy;

			if(shotRate)
				other.gameObject.GetComponent<CharacterShoot>().reloadTime /= multiplyBy;

			if(moveSpeed)
			{
				other.gameObject.GetComponent<CharacterMotor>().moveSpeed += multiplyBy;
				FindObjectOfType<MyCamera>().moveSpeed += multiplyBy;

			}
			Destroy(gameObject);
		}
		
	}
}
