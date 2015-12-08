using UnityEngine;
using System.Collections;

public class EnemyItemDrop : MonoBehaviour {


	public GameObject itemToDrop;
	public GameObject heartToDrop;
	public GameObject coinsToDrop;

	public int numbOfCoins;
	public int powerUpChance = 50;
	public int heartChance = 5;
	private int dropChance;

	private Transform enemyPosition;
	private float characterHealth;
	private Vector3 position;

	public ObjectPooler theCoinPooler;


	// Use this for initialization
	void Start () 
	{
		//coinsToDrop = FindObjectOfType<CoinPickup> ().gameObject;
		numbOfCoins = Random.Range (2, 4);
		dropChance = Random.Range (0, 100);
		enemyPosition = GetComponent<Transform> ();

		theCoinPooler = GameObject.Find ("CoinPooler").GetComponent<ObjectPooler> ();

	}
	

	// Update is called once per frame
	public void ItemDrop () 
	{
		//characterHealth = GetComponent<CharacterHealth> ().health;
		if (GetComponent<CharacterHealth> ().health <= 0) 
		{

			position = enemyPosition.position;

			for (int i = 0; i < numbOfCoins; i++) 
			{
				GameObject newCoin = theCoinPooler.GetPooledObject();
				
				newCoin.transform.position = transform.position;
				newCoin.transform.rotation = transform.rotation;
				newCoin.SetActive(true);
			}

			if (powerUpChance > dropChance)
				Instantiate (itemToDrop, position, Quaternion.identity);

			if(Random.Range(0f, 5f) < heartChance)
				Instantiate (heartToDrop, position, Quaternion.identity);
		}
	}

}
