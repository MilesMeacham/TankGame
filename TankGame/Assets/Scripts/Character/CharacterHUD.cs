using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterHUD : MonoBehaviour {

	public Slider hoverSlider;

	private CharacterJump theCharacterJump;

	// Use this for initialization
	void Start () {

		theCharacterJump = GetComponent<CharacterJump> ();
		hoverSlider = FindObjectOfType<Slider> ();
		
		hoverSlider.maxValue = theCharacterJump.jumpTime;
		
	}
	
	// Update is called once per frame
	void Update () {

		HoverRefill ();
	}

	void HoverRefill() {
		
		hoverSlider.value = theCharacterJump.jumpTimeCounter;
	}
}
