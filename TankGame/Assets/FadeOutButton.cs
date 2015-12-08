using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOutButton : MonoBehaviour {

	private TouchControls theTouchControls;
	private KeyboardInput theKeyboardControls;

	public GameObject flyButton;
	public GameObject shootButton;

	public Image flySR;
	public Image shootSR;

	public float fadeSpeed = 1f;
	public float fadeTime = 1f;

	private float startTime;
	public float duration = 5f;
	public float minimum = 0f;
	public float maximum = 1f;

	// Use this for initialization
	void Start () {
	
		flySR = flyButton.GetComponent<Image> ();
		shootSR = shootButton.GetComponent<Image> ();
		theTouchControls = FindObjectOfType<TouchControls> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (Input.touchCount > 0)
		{
			Touch[] myTouches = Input.touches;
			for(int i = 0; i < Input.touchCount; i++)
			{
				if (myTouches[i].position.x > Screen.width/2)
				{
					shootSR.CrossFadeAlpha(0, 2f, false);
				}

				if (myTouches[i].position.x < Screen.width / 2)
				{
					flySR.CrossFadeAlpha(0, 2f, false);
				}
			}
		}

	}


}
