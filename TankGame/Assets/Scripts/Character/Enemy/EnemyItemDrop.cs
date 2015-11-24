using UnityEngine;
using System.Collections;

public class EnemyItemDrop : MonoBehaviour {


	public GameObject itemToDrop;

	public GameObject coinsToDrop;
	public int numbOfCoins;
	public int powerUpChance = 50;
	private int dropChance;

	private Transform enemyPosition;
	private float characterHealth;
	private Vector3 position;


	// Use this for initialization
	void Start () 
	{
		//coinsToDrop = FindObjectOfType<CoinPickup> ().gameObject;
		numbOfCoins = Random.Range (2, 4);
		dropChance = Random.Range (0, 100);
		enemyPosition = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		characterHealth = GetComponent<CharacterHealth> ().health;
		if (characterHealth <= 0) 
		{

			position = enemyPosition.position;
			for (int i = 0; i < numbOfCoins; i++) 
			{
				Instantiate (coinsToDrop, position, Quaternion.identity);
			}

			if (powerUpChance > dropChance)
				Instantiate (itemToDrop, position, Quaternion.identity);
		}
	}

}
