﻿using UnityEngine;
using System.Collections;

public class EnemyGeneration : MonoBehaviour {

	// Declaring variables
	public Transform generationPoint;
	
	//public GameObject[] thePlatforms;
	private int enemySelector;
	
	private float[] platformWidths;
	
	public ObjectPooler[] objectPools;

	private bool spawningEnemies;
	
	public int enemySpawnChance = 90;
	private int randNumGen;
	
	// Use this for initialization
	void Start () {
		generationPoint = GameObject.Find ("EnemyGenerationPoint").GetComponent<Transform> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Create platform if this object passes the "generationsPoint"
		if (transform.position.x < generationPoint.position.x && !spawningEnemies) {

			transform.position = new Vector3 (transform.position.x + 10, transform.position.y, transform.position.z);
			
			enemySelector = 0;
			
			randNumGen = Random.Range (0, 100);
		
			if(randNumGen > enemySpawnChance && !spawningEnemies)
				StartCoroutine("EnemySpawnCo");
		}

	}

	public IEnumerator EnemySpawnCo()
	{
		spawningEnemies = true;
		int enemiesToSpawn = 4;



		for (int i = 0; i < enemiesToSpawn; i++) {

			// Grab the platform to be placed
			GameObject newEnemy = objectPools[enemySelector].GetPooledObject();

			yield return new WaitForSeconds (0.5f);

			newEnemy.transform.position = generationPoint.position;
			newEnemy.transform.rotation = generationPoint.rotation;
			newEnemy.SetActive (true);

		}
		spawningEnemies = false;





	}

	
}