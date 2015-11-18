using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float minHealth;
	
	public void Update () {

		if (health == minHealth)
			destroyObject ();
	}

	public void addHealth (float healthToAdd)
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
	
	public void addMaxHealth (float maxHealthToAdd)
	{
		maxHealth += maxHealthToAdd;
		
	}
	
	public void removeMaxHealth (float maxHealthToRemove)
	{
		maxHealth -= maxHealthToRemove;
		if (health > maxHealth)
			health = maxHealth;
	}

	public void destroyObject()
	{
		gameObject.SetActive (false);

		health = maxHealth;

	}

}
