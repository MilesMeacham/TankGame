using UnityEngine;
using System.Collections;

public class CharacterShoot : MonoBehaviour {

	public GameObject bullet;
	public ObjectPooler bulletPools;
	public float moveSpeed;
	public float damage;
	public int bulletPenetration = 1;
	public string bulletTag;

	public float reloadTime = 0.5f;
	public bool reloading;

	public bool shotFired;

	//public Animator theAnimator;
	
	void Start () 
	{
		bulletPools = GameObject.Find ("BulletPooler").GetComponent<ObjectPooler> ();

		//theAnimator = GetComponentInChildren<Animator> ();
	}
	
	
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void Shooting (Transform shotStartPos) 
	{

		if (!reloading) 
		{
			shotFired = true;
			//theAnimator.SetBool ("Shot", shotFired);

			bullet = bulletPools.GetPooledObject ();
			bullet.GetComponent<BulletMovement> ().bulletMoveSpeed = moveSpeed;
			bullet.GetComponent<BulletMovement> ().bulletDamage = damage;
			bullet.GetComponent<BulletMovement> ().collisionLimit = bulletPenetration;
			bullet.gameObject.tag = bulletTag;
			bullet.transform.position = shotStartPos.transform.position;
			bullet.transform.rotation = shotStartPos.transform.rotation;
			bullet.SetActive (true);
			reloading = true;

			StartCoroutine("ReloadingCo");
		}


	}

	IEnumerator ReloadingCo ()
	{
		yield return new WaitForSeconds (reloadTime);
		reloading = false;

	}
}
