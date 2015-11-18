using UnityEngine;
using System.Collections;

public class EnemyItemDrop : MonoBehaviour {

	public GameObject itemToDrop;

	public int numbOfItems;

	private Transform enemyPosition;
	private float characterHealth;
	private Vector3 position;

	// Use this for initialization
	void Start () 
	{

		enemyPosition = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		characterHealth = GetComponent<CharacterHealth> ().health;
		if (characterHealth <= 0) 
		{
			position = enemyPosition.position;
			for (int i = 0; i < numbOfItems; i++) {
				Instantiate (itemToDrop, position, Quaternion.identity);
			}
		}
	}

}
