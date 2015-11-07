using UnityEngine;
using System.Collections;

public class Player : CharacterController {



	public float playerHealth = 20;
	public float playerDamage = 5;

	// Use this for initialization
	void Start () {
		health = playerHealth;
		maxHealth = playerHealth;
		damage = playerDamage;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.K))
		    base.removeHealth(5f);
		if (Input.GetKeyDown (KeyCode.L))
			base.addHealth(5f);
		if (Input.GetKeyDown (KeyCode.P))
			base.addMaxHealth(5);
		if (Input.GetKeyDown (KeyCode.O))
			base.removeMaxHealth(5);
		
	}



}
