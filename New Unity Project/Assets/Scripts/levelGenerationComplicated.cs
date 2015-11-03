using UnityEngine;
using System.Collections;

public class levelGenerationComplicated : MonoBehaviour {

	// Declaring variables
	public GameObject platform;
	public Transform generationsPoint;
	private float distanceBetween;

	public float distanceBetweenMin = 1;
	public float distanceBetweenMax = 4;

	private float platformWidth;


	//public GameObject[] thePlatforms;
	private int platformSelector;

	private float[] platformWidths;

	public ObjectPooler[] objectPools;

	// Use this for initialization
	void Start () {

		//platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;

		//Set the length of the "platformWidths" array to the length of the "objectPools" array
		platformWidths = new float[objectPools.Length];

		//Find the length of all the objects in the "objectPools" array and set the elements of the "platformWidths" array to equal those respectivly
		for (int i = 0; i < objectPools.Length; i++)
			platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;


	}
	
	// Update is called once per frame
	void Update () {
	
		// Create platform if this object passes the "generationsPoint"
		if (transform.position.x < generationsPoint.position.x) {

			// Choose a random distance to make the gap
			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

			// Choose a random platform
			platformSelector = Random.Range (0, objectPools.Length);

			// Set this object to the position to create the platform
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);

			// Grab the platform to be placed
			GameObject newPlatform = objectPools[platformSelector].GetPooledObject();

			// Place the platform and make it visible
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);


			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);


		}

	}
}
