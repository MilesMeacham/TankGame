using UnityEngine;
using System.Collections;

public class EnemyGeneration : MonoBehaviour {

	// Declaring variables
	public Transform generationPoint;
	
	//public GameObject[] thePlatforms;
	private int enemySelector;
	
	private float[] platformWidths;
	
	public ObjectPooler[] objectPools;

	private bool spawningEnemies = false;
	
	public int enemySpawnChance = 90;
	private int randNumGen;

	GameObject[] enemyCount;

	public float randEnemyThreshold;
	public ObjectPooler theEnemyPool;

	public float maxTimeNoEnemy = 5f;
	public float timeSinceLastSpawn;

	// Use this for initialization
	void Start () {
		generationPoint = GameObject.Find ("EnemyGenerationPoint").GetComponent<Transform> ();
		timeSinceLastSpawn = maxTimeNoEnemy;
	}

	void Update () {
//		enemyCount = GameObject.FindGameObjectsWithTag("enemy");
	//	if(!enemyCount)
	//		spawningEnemies = false;
	//	if(enemyCount)
	//		spawningEnemies = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Create enemy if this object passes the "generationsPoint"
		if (transform.position.x < generationPoint.position.x && !spawningEnemies) {

			transform.position = new Vector3 (transform.position.x + 10, transform.position.y, transform.position.z);
			
			enemySelector = 0;
			
			randNumGen = Random.Range (0, 100);
		
			if(randNumGen > enemySpawnChance && !spawningEnemies)
				StartCoroutine("EnemySpawnCo");
		}

		if(Random.Range(0f, 100f) < randEnemyThreshold || timeSinceLastSpawn <= 0)
		{
			GameObject newEnemy = theEnemyPool.GetPooledObject();
			
			Vector3 enemyPosition = new Vector3 (0f, 0f, 0f);
			
			newEnemy.transform.position = transform.position + enemyPosition;
			newEnemy.transform.rotation = transform.rotation;
			newEnemy.SetActive(true);

			timeSinceLastSpawn = maxTimeNoEnemy;
		}

		timeSinceLastSpawn -= Time.deltaTime;

	}

	public IEnumerator EnemySpawnCo()
	{
		spawningEnemies = true;
		int enemiesToSpawn = 4;



		for (int i = 0; i < enemiesToSpawn; i++) {

			// Grab the enemy to be placed
			GameObject newFlyingEnemy = objectPools[enemySelector].GetPooledObject();

			if(i == enemiesToSpawn)
			{
				newFlyingEnemy.AddComponent<EnemyItemDrop>();
			}


			yield return new WaitForSeconds (0.5f);

			newFlyingEnemy.transform.position = generationPoint.position;
			newFlyingEnemy.transform.rotation = generationPoint.rotation;
			newFlyingEnemy.SetActive (true);

		}

		spawningEnemies = false;





	}

	
}
