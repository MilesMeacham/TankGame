using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float minHealth;
	public float damage;
	public float moveSpeed;
	public float jumpForce;
	public float jumpTime;



	void character () {
		health = 10;
		maxHealth = 10;
		minHealth = 0;
		damage = 5;
		moveSpeed = 5;
		jumpForce = 0.2f;
		jumpTime = 2;

	}

	void character (float h, float mh, float d, float ms, float jf, float jt) 
	{
		health = h;
		maxHealth = mh;
		damage = d;
		moveSpeed = ms;
		jumpForce = jf;
		jumpTime = jt;
	}

	void addHealth (float healthToAdd)
	{
		health += healthToAdd;
		if (health > maxHealth)
			health = maxHealth;
	}

	void removeHealth (float healthToRemove)
	{
		health -= healthToRemove;
		if (health < healthToRemove)
			health = minHealth;
	}





	float getHealth () 
	{
		return health;
	}

	float getDamage () 
	{
		return damage;
	}

	float getMoveSpeed () 
	{
		return moveSpeed;
	}

	float getJumpForce () 
	{
		return jumpForce;
	}

	float getJumpTime () 
	{
		return jumpTime;
	}



}
