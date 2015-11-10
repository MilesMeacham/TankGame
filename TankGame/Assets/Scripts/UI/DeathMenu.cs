using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

	private string MainMenu = "MainMenu";

	public void RestartGame()
	{
		FindObjectOfType<GameManager> ().ResetGame ();
	}

	public void QuitToMainMenu()
	{
		Application.LoadLevel (MainMenu);

	}

}
