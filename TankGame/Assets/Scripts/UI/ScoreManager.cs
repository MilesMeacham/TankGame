using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecond = 1;

	public bool scoreIncrease;

	// Use this for initialization
	void Start () {
		// Check for any highScore
		if (PlayerPrefs.HasKey ("HighScore"))
			highScoreCount = PlayerPrefs.GetFloat ("HighScore");
	}



	// Update is called once per frame
	void Update () {
	
		if (scoreIncrease)
			scoreCount += pointsPerSecond * Time.deltaTime;

		if (scoreCount > highScoreCount) 
		{
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", highScoreCount);

		}
		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);

	}
}
