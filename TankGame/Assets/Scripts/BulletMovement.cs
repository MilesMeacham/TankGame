using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public int bulletMoveSpeed = 20;
	public float bulletLifeSpan = 2f;


	void Start () {
		//StartCoroutine ("BulletDestroyCo");


	}

	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Transform> ().transform.Translate (Vector2.right * bulletMoveSpeed * Time.deltaTime);


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Deathzone" || other.gameObject.tag == "Enemy")
			gameObject.SetActive (false);
		
	}

	public IEnumerator BulletDestroyCo()
	{

		yield return new WaitForSeconds (bulletLifeSpan);
		gameObject.SetActive (false);

	}

}
