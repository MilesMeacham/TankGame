using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public int moveSpeed = 20;
	public float bulletLifeSpan = 2f;


	void Start () {
		//StartCoroutine ("BulletDestroyCo");


	}

	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Transform> ().transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Deathzone")
			gameObject.SetActive (false);
		
	}

	public IEnumerator BulletDestroyCo()
	{

		yield return new WaitForSeconds (bulletLifeSpan);
		gameObject.SetActive (false);

	}

}
