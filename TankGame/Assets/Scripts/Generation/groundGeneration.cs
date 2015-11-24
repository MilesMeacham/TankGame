using UnityEngine;
using System.Collections;

public class groundGeneration : MonoBehaviour {

	// Declaring variables
	public GameObject platform;
	public Transform generationsPoint;
	private int distanceBetween;
	
	public int distanceBetweenMin = 5;
	public int distanceBetweenMax = 20;
	
	private float platformWidth;

	public GameObject[] theObstacles;
	public bool obstacleTime = true;

	private int platformSelector;
	
	private float[] platformWidths;
	
	public ObjectPooler[] objectPools;
	private float[] theObstacleWidth;

	private int randObstacleTime;
	private int minObstacleFreq = 5;
	private int maxObstacleFreq = 20;
//	private bool placingGap;

	private int gapChance = 90;
	public int gapChanceGen;

	public GameObject newPlatform;
	public GameObject newObstacle;

	// Use this for initialization
	void Start () {
	
		//platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
		
		//Set the length of the "platformWidths" array to the length of the "objectPools" array
		platformWidths = new float[objectPools.Length];
		
		//Find the length of all the objects in the "objectPools" array and set the elements of the "platformWidths" array to equal those respectivly
		for (int i = 0; i < objectPools.Length; i++)
			platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;

		theObstacleWidth = new float[theObstacles.Length];
		for (int i = 0; i < theObstacles.Length; i++) 
		{
			theObstacleWidth[i] = theObstacles[i].GetComponent<BoxCollider2D> ().size.x;
			
		}

		if(this.name == "FloorGenerator")
			StartCoroutine("ObstacleCo");
	}
	
	// Update is called once per frame
	void Update () {


		// Create platform if this object passes the "generationsPoint"
		if (transform.position.x < generationsPoint.position.x) {

			if(!obstacleTime)
			{
				platformSelector = 0;

				gapChanceGen = Random.Range (0, 100);

				if(gapChanceGen > gapChance)
					distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
				

				
				// Grab the platform to be placed
				newPlatform = objectPools[platformSelector].GetPooledObject();

				// Set this object to the position to create the platform
				transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);
				
				// Place the platform and make it visible
				newPlatform.transform.position = transform.position;
				newPlatform.transform.rotation = transform.rotation;
				newPlatform.SetActive (true);
				
				transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
				
				distanceBetween = 0;
				


			}
			else
			{
				int rand = Random.Range (0, theObstacles.Length);

				newObstacle = theObstacles[rand];
				
				// Set this object to the position to create the platform
				transform.position = new Vector3 (transform.position.x + (theObstacleWidth[rand] / 2) + distanceBetween, transform.position.y, transform.position.z);
				
				// Place the platform and make it visible
				newObstacle.transform.position = transform.position;
				newObstacle.transform.rotation = transform.rotation;
				Instantiate(newObstacle);
				
				transform.position = new Vector3 (transform.position.x + (theObstacleWidth[rand] / 2), transform.position.y, transform.position.z);
				
				distanceBetween = 0;

				StartCoroutine("ObstacleCo");

			}





		}


		
	}

	public IEnumerator ObstacleCo()
	{
		obstacleTime = false;
		randObstacleTime = Random.Range (minObstacleFreq, maxObstacleFreq);
		yield return new WaitForSeconds(randObstacleTime);
		obstacleTime = true;





	}


}



