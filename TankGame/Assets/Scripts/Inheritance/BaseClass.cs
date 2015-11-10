using UnityEngine;
using System.Collections;

public class BaseClass : MonoBehaviour {

	protected float health;
	protected float maxHealth;
	protected float minHealth;
	protected float damage;




	// Use this for initialization
	protected void Start () {
		health = 10;
		maxHealth = 10;
		minHealth = 0;
		damage = 5;
	}

	protected void Update () {

		if (health == minHealth)
			destroyObject ();
	}

	protected void addHealth (float healthToAdd)
	{
		health += healthToAdd;
		if (health > maxHealth)
			health = maxHealth;
	}

	
	public void removeHealth (float healthToRemove)
	{
		health -= healthToRemove;
		if (health < healthToRemove)
			health = minHealth;
	}
	
	protected void addMaxHealth (float maxHealthToAdd)
	{
		maxHealth += maxHealthToAdd;
		
	}
	
	public void removeMaxHealth (float maxHealthToRemove)
	{
		maxHealth -= maxHealthToRemove;
		if (health > maxHealth)
			health = maxHealth;
	}

	protected void destroyObject()
	{
		gameObject.SetActive (false);

		health = maxHealth;

	}

}
