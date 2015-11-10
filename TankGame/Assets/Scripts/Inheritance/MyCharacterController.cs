using UnityEngine;
using System.Collections;

public class MyCharacterController : BaseClass {



	public float moveSpeed;
	public float jumpForce;
	protected float jumpTime;
	protected float jumpTimeCounter;

	protected GameObject bullets;
	public ObjectPooler bulletPools;

	protected Rigidbody2D rb;


	protected new void Start () {
		base.Start ();
		bulletPools = GameObject.Find ("BulletPooler").GetComponent<ObjectPooler> ();

	}

	protected void Jumping (Rigidbody2D rb, float jumpForce) {
		if (jumpTimeCounter > 0)
		{
			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y + jumpForce);
			jumpTimeCounter -= Time.deltaTime;
		}
	}


	//protected void Movement (Rigidbody2D rb, float moveSpeed) {
	protected void Movement (){
		rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
	}

	protected void VerticalMovement (){
		rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
	}

	protected void Shooting (Transform shotStartPos) {
		bullets = bulletPools.GetPooledObject ();
		bullets.transform.position = shotStartPos.transform.position;
		bullets.transform.rotation = shotStartPos.transform.rotation;
		bullets.SetActive (true);
	}
	


}
