using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {


	public string mainLevel;

	public Image startButton;

	public void PlayGame()
	{
		StartCoroutine ("TextFlashCo");
	}


	public void QuitGame()
	{
		Application.Quit ();
	}

	IEnumerator TextFlashCo()
	{
		startButton.enabled = false;
		yield return new WaitForSeconds(0.3f);
		startButton.enabled = true;
		yield return new WaitForSeconds(0.3f);
		startButton.enabled = false;
		yield return new WaitForSeconds(0.3f);
		startButton.enabled = true;
		yield return new WaitForSeconds(0.3f);
		startButton.enabled = false;
		yield return new WaitForSeconds(0.3f);
		startButton.enabled = true;
		yield return new WaitForSeconds(0.3f);
		Application.LoadLevel (mainLevel);
	}

}
