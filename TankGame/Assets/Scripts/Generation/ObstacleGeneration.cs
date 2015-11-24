﻿using UnityEngine;
using System.Collections;

public class ObstacleGeneration : MonoBehaviour {
	
	// Declaring variables
	public GameObject theObstacle;
	public Transform generationsPoint;
	private int distanceBetween;
	
	public int distanceBetweenMin = 5;
	public int distanceBetweenMax = 20;
	
	private float platformWidth;
	
	
	public GameObject[] theObstacles;
	public bool obstacleTime = false;
	
	private int platformSelector;
	
	private float[] platformWidths;
	
	public ObjectPooler[] objectPools;
	private float[] theObstacleWidth;
	
	private int randGapTime;
	//	private int minGapTime = 5;
	//	private int maxGapTime = 20;
	//	private bool placingGap;
	
	private int gapChance = 90;
	public int gapChanceGen;
	
	public GameObject newPlatform;
	
	// Use this for initialization
	void Start () {
		
		//platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
		
		//Set the length of the "platformWidths" array to the length of the "objectPools" array
		platformWidths = new float[objectPools.Length];
		
		//Find the length of all the objects in the "objectPools" array and set the elements of the "platformWidths" array to equal those respectivly
		for (int i = 0; i < objectPools.Length; i++)
			platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;

		for (int i = 0; i < theObstacles.Length; i++) 
		{
			theObstacleWidth[i] = theObstacles[i].GetComponent<BoxCollider2D> ().size.x;

		}
		
		
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
				
				
			}
			else
			{
				int rand = Random.Range (0, theObstacles.Length);
				
				newPlatform = theObstacles[rand];
				
			}
			
			// Set this object to the position to create the platform
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);
			
			// Place the platform and make it visible
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
			
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
			
			distanceBetween = 0;
			
			//if(!placingGap)
			//	StartCoroutine("PlaceGapCo");
			
			
			
		}
		
		
		
	}
	/*
	public IEnumerator PlaceGapCo()
	{
		placingGap = true;
		randGapTime = Random.Range (minGapTime, maxGapTime);
		yield return new WaitForSeconds(randGapTime);
		distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
		yield return new WaitForSeconds(2.5f);
		distanceBetween = 0;
		placingGap = false;





	}
*/
	
}



