using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PowerUp : MonoBehaviour {

	public float multiplyBy;

	public string descriptionText;
	//public Text descriptionText;

	public bool damage;
	public bool maxHealth;
	public bool shotRate;
	public bool moveSpeed;
	private GameObject mySprite;

	private GameManager theGameManager;


	// Use this for initialization
	void Start () {
		theGameManager = FindObjectOfType<GameManager> ();

		mySprite = GameObject.Find ("Art");
		int rand = Random.Range (0, 3);

		if (rand == 0)
		{

			damage = true;
		}
		else if (rand == 1)
		{
			maxHealth = true;

		}
		else if (rand == 2) 
		{
			shotRate = true;
			multiplyBy = 1.1f;

		}
		else 
			moveSpeed = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.layer == 8) 
		{
			GetComponent<Rigidbody2D> ().gravityScale = 0;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0);
		}

		if (other.gameObject.tag == "Player") 
		{
			if(damage)
			{
				descriptionText = "Damage Up";
				other.gameObject.GetComponent<CharacterShoot>().damage *= multiplyBy;
			}

			if(maxHealth)
			{
				other.gameObject.GetComponent<CharacterHealth>().addMaxHealth(1);
				descriptionText = "Max Health Up";
			}

			if(shotRate)
			{
				other.gameObject.GetComponent<CharacterShoot>().reloadTime /= multiplyBy;
				descriptionText = "Shot Rate Up";
			}

			if(moveSpeed)
			{
				//other.gameObject.GetComponent<CharacterMotor>().moveSpeed += multiplyBy;
				//FindObjectOfType<MyCamera>().moveSpeed += multiplyBy;

			}
			//mySprite.SetActive (false);

			theGameManager.DescriptionText(descriptionText);

			Destroy(gameObject);

			//StartCoroutine ("DescriptionCo");
		}
		
	}



}
