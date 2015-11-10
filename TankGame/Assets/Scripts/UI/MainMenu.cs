using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	public string mainLevel;

	public void PlayGame()
	{
		Application.LoadLevel (mainLevel);
	}


	public void QuitGame()
	{
		Application.Quit ();
	}
}
