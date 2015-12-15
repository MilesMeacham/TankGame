using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float bulletMoveSpeed = 20;
	public float bulletLifeSpan = 2f;
	public float bulletDamage;

	private int bulletCollision;
	public int collisionLimit = 2;

	public bool bulletDestroy;

	void Start () {



	}

	// Update is called once per frame
	void Update () {
		if(!bulletDestroy)
			StartCoroutine ("BulletDestroyCo");

		this.gameObject.GetComponent<Transform> ().transform.Translate (Vector2.right * bulletMoveSpeed * Time.deltaTime);


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
			bulletCollision++;
		//if(other.gameObject.tag == "Deathzone" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
		if (bulletCollision > collisionLimit) 
		{
			gameObject.SetActive (false);
			bulletCollision = 0;
		}

		if (other.gameObject.tag == "Deathzone")
			gameObject.SetActive (false);

		if (other.gameObject.tag == "Destructable") 
		{
			gameObject.SetActive (false);
		}


		if (other.gameObject.layer == 8) {
			gameObject.SetActive (false);
			bulletCollision = 0;
		}

	}
	

	void OnColliderEnter2D (Collision2D other)
	{

	}

	public IEnumerator BulletDestroyCo()
	{
		bulletDestroy = true;
		yield return new WaitForSeconds (bulletLifeSpan);
		bulletCollision = 0;
		bulletDestroy = false;
		gameObject.SetActive (false);

	}

}
