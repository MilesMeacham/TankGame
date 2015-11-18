using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecond = 1;
	public float additionalScore = 0;

	public bool scoreIncrease;

	public float startingPosition;
	public float distanceTraveled;

	public GameObject player;

	// Use this for initialization
	void Start () {
		// Check for any highScore
		if (PlayerPrefs.HasKey ("HighScore"))
			highScoreCount = PlayerPrefs.GetFloat ("HighScore");
	

		player = GameObject.FindGameObjectWithTag ("Player");
		startingPosition = player.GetComponent<Transform> ().position.x;

	}
	// Update is called once per frame
	void Update () {
	
		distanceTraveled = player.GetComponent<Transform> ().position.x / 10;

		if (scoreIncrease)
			scoreCount = distanceTraveled + additionalScore;
			//scoreCount += pointsPerSecond * Time.deltaTime;

		if (scoreCount > highScoreCount) 
		{
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", highScoreCount);

		}
		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);

	}
}
