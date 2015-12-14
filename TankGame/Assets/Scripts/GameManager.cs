using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Transform levelGenerator;
	private Vector3 levelStartPoint;

	public Transform ceilingGenerator;
	private Vector3 ceilingStartPoint;

	public CharacterMotor player;
	private Vector3 playerStartPoint;

	private levelDestruction[] platformList;

//	private float deathDelay = 0.5f;

	private ScoreManager theScoreManager;

	private Camera cameraController;
	private Vector3 cameraStartPoint;

	public DeathMenu gameOverScreen;

	public bool restarted;

	public Text descriptionText;

	public float distanceTraveled;
	public float milestone;
	public float milestoneIncrement;
	public float multiplier;

	// Use this for initialization
	void Start () {
	
		levelStartPoint = levelGenerator.position;
		ceilingStartPoint = ceilingGenerator.position;
		playerStartPoint = player.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();

		cameraController = FindObjectOfType<Camera> ();

		cameraStartPoint = cameraController.GetComponent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () {

		distanceTraveled = player.GetComponent<Transform> ().position.x / 10;

		if (distanceTraveled > milestone) 
		{
			milestone += milestoneIncrement;

			milestoneIncrement = milestoneIncrement * multiplier;

			player.moveSpeed += multiplier;
			FindObjectOfType<MyCamera>().moveSpeed += multiplier;

		}
	
		if (player.GetComponent<CharacterHealth> ().health == 0) 
		{
			restarted = true;
			RestartGame ();


		}
	}

	public void RestartGame()
	{
		player.gameObject.SetActive (false);
		theScoreManager.scoreIncrease = false;

		gameOverScreen.gameObject.SetActive (true);

		//StartCoroutine ("RestartGameCo");
	}

	public void ResetGame()
	{
		theScoreManager.scoreCount = 0;
		theScoreManager.additionalScore = 0;
		theScoreManager.scoreIncrease = true;
		Application.LoadLevel (1);
		/*
		gameOverScreen.gameObject.SetActive (false);
		platformList = FindObjectsOfType<levelDestruction> ();
		for (int i = 0; i < platformList.Length; i++)
			platformList [i].gameObject.SetActive (false);
		
		player.GetComponent<CharacterHealth> ().health = player.GetComponent<CharacterHealth> ().maxHealth;
		cameraController.transform.position = cameraStartPoint;
		player.transform.position = playerStartPoint;
		//player.GetComponent<CharacterHealth> ().health = GetComponent<CharacterHealth> ().maxHealth;
		levelGenerator.position = levelStartPoint;
		ceilingGenerator.position = ceilingStartPoint;
		player.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.additionalScore = 0;
		theScoreManager.scoreIncrease = true;
		restarted = false;
		*/
	}


	public void DescriptionText(string myText)
	{
		StartCoroutine ("DescriptionCo", myText);

	}

	public IEnumerator DescriptionCo(string text)
	{
		descriptionText.text = text;
		descriptionText.gameObject.SetActive (true);
		yield return new WaitForSeconds (2f);
		descriptionText.gameObject.SetActive (false);

		
	}

/*
	public IEnumerator RestartGameCo()
	{
		player.gameObject.SetActive (false);
		theScoreManager.scoreIncrease = false;
		yield return new WaitForSeconds (deathDelay);
		platformList = FindObjectsOfType<levelDestruction> ();
		for (int i = 0; i < platformList.Length; i++)
			platformList [i].gameObject.SetActive (false);

		player.transform.position = playerStartPoint;
		cameraController.transform.position = cameraStartPoint;
		levelGenerator.position = levelStartPoint;
		ceilingGenerator.position = ceilingStartPoint;
		player.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncrease = true;

	}
*/

}
