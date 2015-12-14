using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float minHealth;

	public bool invincible;
	public float invincibilityTime = 2;
	public bool flashing;

	private GameObject playerSprite;

	public void Start () {
		health = maxHealth;
		if(gameObject.tag == "Player")
			playerSprite = GameObject.Find ("PlayerArt");
	}

	public void Update () {

		if (health == minHealth)
			destroyObject ();

		if (invincible && gameObject.tag == "Player" && !flashing) 
		{

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
		if(maxHealth != 9)
		{
			maxHealth += maxHealthToAdd;
			health = maxHealth;

			if (gameObject.tag == "Player") 
			{
				GameObject.Find("Hearts").GetComponent<MaxHealthManager>().ActivateHeart();
			}
		}
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
		if(gameObject.layer == 11)
		{
			EnemyItemDrop theEnemy = GetComponent<EnemyItemDrop>();
			theEnemy.ItemDrop();
			health = maxHealth;		
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
