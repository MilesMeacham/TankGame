using UnityEngine;
using System.Collections;

public class EnemyShootLogic : EnemyBaseClass {

	public float startShootingDistance = 10;
	public float endShootingDistance = 9;
	private float actualDistanceFromPlayer;

	public FlyingEnemyBombDrop theFlyingEnemyBombDrop;
	
	private bool timedShot;
	private Transform enemyShotStartPos;

	public float shotWaitTime = 0.5f;
	public int numOfShots = 1;
	
	private GameObject thePlayer;
	
	// Use this for initialization
	new void Start () {
		base.Start();
		
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		theFlyingEnemyBombDrop = GetComponent<FlyingEnemyBombDrop> ();
		
		enemyShotStartPos = transform.FindChild ("ShotStartPos").gameObject.GetComponent<Transform> ();
		
		
	}
	
	void Update () {
		
		actualDistanceFromPlayer = transform.position.x - thePlayer.transform.position.x;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
		if (actualDistanceFromPlayer <= startShootingDistance && actualDistanceFromPlayer >= endShootingDistance && !timedShot)
			StartCoroutine("TimedShotCo");
		
	}
	

	
	IEnumerator TimedShotCo(){
		
		timedShot = true;

		int i = 0;

		while (i < numOfShots) 
		{
			yield return new WaitForSeconds (shotWaitTime);
			theFlyingEnemyBombDrop.Shooting (enemyShotStartPos);
			i++;
		}

		timedShot = false;
	}
	
}