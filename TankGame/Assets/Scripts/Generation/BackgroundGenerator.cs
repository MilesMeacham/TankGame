using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour {

	// Declaring variables
	public GameObject platform;
	public Transform generationsPoint;
	
	private float platformWidth;
	
	private int platformSelector;

	private float[] platformWidths;
	
	public BackgroundObjectPooler[] objectPools;
	private float[] theObstacleWidth;

	public GameObject newBackground;


	
	// Use this for initialization
	void Start () 
	{
		
		//platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
		
		//Set the length of the "platformWidths" array to the length of the "objectPools" array
		platformWidths = new float[objectPools.Length];
		
		//Find the length of all the objects in the "objectPools" array and set the elements of the "platformWidths" array to equal those respectivly
		for (int i = 0; i < objectPools.Length; i++)
			platformWidths [i] = 30;

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		// Create platform if this object passes the "generationsPoint"
		if (transform.position.x < generationsPoint.position.x) 
		{

			// Set this object to the position to create the platform
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, GetComponentInParent<Transform>().position.z);

			for(int i = 0; i < objectPools.Length; i++)
			{


				// platformSelector = 0;

				// Grab the platform to be placed
				newBackground = objectPools[i].GetPooledObject();
				

				
				// Place the platform and make it visible
				newBackground.transform.position = transform.position;
				newBackground.transform.rotation = transform.rotation;
				newBackground.SetActive (true);
				


			}
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
		}
		
	}
}
