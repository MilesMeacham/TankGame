using UnityEngine;
using System.Collections;

public class MaxHealthManager : MonoBehaviour {

	public GameObject[] myHearts;
	public bool heartAdded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateHeart()
	{
		int i = 0;
		heartAdded = false;
		while (!heartAdded) 
		{
			if (!myHearts [i].activeInHierarchy) {
				myHearts [i].SetActive (true);
				heartAdded = true;
			}
			i++;
		
		}


		

	}
}
