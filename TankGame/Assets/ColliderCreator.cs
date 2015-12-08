using UnityEngine;
using System.Collections;

public class ColliderCreator : MonoBehaviour {


	public Camera cam;
	public float depth = 100f;
	public float distanceQuery = 1f;

	float _distanceQuery = 1000f;
	float _skin2D = 0.05f;
	
	GameObject top, bottom, left, right;
	GameObject[] barriers;
	
	void Start() {
		//Allows overriding on what camera to use for positioning
		//Will use the main camera when one isn't provided.
		if(cam == null)
			cam = Camera.main;


		Create2DBarriers();
	}
	
	private void Create2DBarriers() {
		top = GameObject.CreatePrimitive(PrimitiveType.Cube);
		top.name = "Top";
		top.transform.localScale = new Vector3(0f, _skin2D, 0f);
		
		bottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
		bottom.name = "Bottom";
		bottom.transform.localScale = new Vector3(0f, _skin2D, 0f);
		
		left = GameObject.CreatePrimitive(PrimitiveType.Cube);
		left.name = "Left";
		left.transform.localScale = new Vector3(_skin2D, 0f, 0f);
		
		right = GameObject.CreatePrimitive(PrimitiveType.Cube);
		right.name = "Right";
		right.transform.localScale = new Vector3(_skin2D, 0f, 0f);
		
		barriers = new GameObject[] { top, bottom, left, right };
		
		foreach(var b in barriers) {
			DestroyImmediate(b.GetComponent<Collider>());
			//no need to render these.
			DestroyImmediate(b.GetComponent<Renderer>());
			
			b.transform.parent = cam.transform;
			
			var bc = b.AddComponent<BoxCollider2D>();
			var rb = b.AddComponent<Rigidbody2D>();
			rb.isKinematic = true;
			bc.isTrigger = true;
			b.tag = ("Deathzone");
		}
	}
	
	private void Create3DBarriers() {
		top = GameObject.CreatePrimitive(PrimitiveType.Cube);
		top.name = "Top";
		top.transform.localScale = new Vector3(100f, 0f, 0f);
		
		bottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
		bottom.name = "Bottom";
		bottom.transform.localScale = new Vector3(100f, 0f, 0f);
		
		left = GameObject.CreatePrimitive(PrimitiveType.Cube);
		left.name = "Left";
		left.transform.localScale = new Vector3(0f, 100f, 0f);
		
		right = GameObject.CreatePrimitive(PrimitiveType.Cube);
		right.name = "Right";
		right.transform.localScale = new Vector3(0f, 100f, 0f);
		
		barriers = new GameObject[] { top, bottom, left, right };
		
		foreach(var b in barriers) {
			b.transform.parent = cam.transform;
			var rb = b.AddComponent<Rigidbody>();
			rb.isKinematic = true;
			
			//no need to render these.
			DestroyImmediate(b.GetComponent<Renderer>());
		}
		
		SetScales();
		SetPositions();
	}


	private void SetScales() {
		var verticalSize = cam.orthographicSize * 2.0f ;
		var horizontalSize = verticalSize * cam.aspect;
		
		top.transform.localScale = new Vector3(horizontalSize, _skin2D, 0f);
		bottom.transform.localScale = new Vector3(horizontalSize, _skin2D, 0f);
		left.transform.localScale = new Vector3(_skin2D, verticalSize, 0f);
		right.transform.localScale = new Vector3(_skin2D, verticalSize, 0f);
	}
	
	private void SetPositions() {
		//Camera rotations mess up the positions
		var camRot = cam.transform.rotation;
		cam.transform.rotation = Quaternion.identity;
		
		top.transform.position = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, _distanceQuery));
		bottom.transform.position = cam.ViewportToWorldPoint(new Vector3(0.5f, -0.05f, _distanceQuery));
		left.transform.position = cam.ViewportToWorldPoint(new Vector3(-0.05f, 0.5f, _distanceQuery));
		right.transform.position = cam.ViewportToWorldPoint(new Vector3(1.5f, 0.5f, _distanceQuery));
		
		foreach(var b in barriers)
			b.transform.localPosition = ZeroZ(b.transform);
		
		//reset to the real rotation.
		cam.transform.rotation = camRot;
	}
	
	//Make each cube's position start at the camera's z position and extend outwards.
	private Vector3 ZeroZ(Transform t) {
		var pos = t.localPosition;
		pos.z = t.localScale.z / 2f;
		
		return pos;
	}
	
	void FixedUpdate() {
		if(cam == null)
			cam = Camera.main;
		
		distanceQuery = Mathf.Clamp01(distanceQuery);
		_distanceQuery = cam.farClipPlane * distanceQuery;
		_distanceQuery = Mathf.Clamp(_distanceQuery, cam.nearClipPlane, cam.farClipPlane);
		
		SetScales();
		SetPositions();
	}
}

