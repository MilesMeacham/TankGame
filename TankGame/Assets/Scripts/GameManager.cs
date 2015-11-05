using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform levelGenerator;
	private Vector3 levelStartPoint;

	public Transform ceilingGenerator;
	private Vector3 ceilingStartPoint;

	public PlayerController player;
	private Vector3 playerStartPoint;

	private levelDestruction[] platformList;

	private float deathDelay = 0.5f;

	private ScoreManager theScoreManager;

	private Camera cameraController;
	private Vector3 cameraStartPoint;


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
	
	}

	public void RestartGame()
	{
		StartCoroutine ("RestartGameCo");
	}

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


}
