using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float minHealth;

	public bool invincible;
	public float invincibilityTime = 2;
	public bool flashing;

	public void Start () {
		health = maxHealth;
	}

	public void Update () {

		if (health == minHealth)
			destroyObject ();

		if (invincible && gameObject.tag == "Player" && !flashing) 
		{
			GameObject playerSprite = GameObject.Find ("PlayerArt");
			StartCoroutine ("SpriteFlashCo", playerSprite);

		}
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

		if(gameObject.layer == 10)
		{
			EnemyItemDrop theEnemy = GetComponent<EnemyItemDrop>();
			theEnemy.ItemDrop();
			health = maxHealth;
			gameObject.GetComponent<GroundEnemy>().timedShot = false;

		}

	}

	public void Invincibility()
	{
		StartCoroutine ("InvincibilityCo");
	}

	public IEnumerator InvincibilityCo()
	{
		invincible = true;
		yield return new WaitForSeconds(invincibilityTime);
		invincible = false;
		
	}

	public IEnumerator SpriteFlashCo(GameObject sprite)
	{
		flashing = true;
		while (invincible) {
			sprite.SetActive (false);
			yield return new WaitForSeconds (0.1f);
			sprite.SetActive (true);
			yield return new WaitForSeconds (0.1f);
		}
		flashing = false;
	}

}
