using UnityEngine;
using System.Collections;

public class CharacterShoot : MonoBehaviour {

	public GameObject bullet;
	public ObjectPooler bulletPools;
	public float moveSpeed;
	public float damage;
	public string bulletTag;
	
	void Start () {
		bulletPools = GameObject.Find ("BulletPooler").GetComponent<ObjectPooler> ();
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Shooting (Transform shotStartPos) {
		bullet = bulletPools.GetPooledObject ();
		bullet.GetComponent<BulletMovement> ().bulletMoveSpeed = moveSpeed;
		bullet.GetComponent<BulletMovement> ().bulletDamage = damage;
		bullet.gameObject.tag = bulletTag;
		bullet.transform.position = shotStartPos.transform.position;
		bullet.transform.rotation = shotStartPos.transform.rotation;
		bullet.SetActive (true);
	}

}
