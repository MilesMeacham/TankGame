using UnityEngine;
using System.Collections;

public class CoinSpread : MonoBehaviour {

	public Rigidbody2D rb;
	public float verticalForce;
	public float horizontalForce;

	public bool moved = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();




	}
	
	// Update is called once per frame
	void Update () {

		if (!moved)
			CoinMovement ();

	}

	void CoinMovement () {
		moved = true;
		verticalForce = Random.Range (150f, 350f);
		horizontalForce = Random.Range (-100f, 100f);
		
		rb.AddForce (Vector3.up * verticalForce);
		rb.AddForce (Vector3.left * horizontalForce);
		rb.gravityScale = 1;
	}
}
