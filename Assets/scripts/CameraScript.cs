using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CameraScript : MonoBehaviour {
	public GameObject player;
	public Text scoreText;
	public Text highScoreText;
	public GameOver gameOver;
	public GameObject step;
	public GameObject wall;
	private int score = 0;
	private int scoreUpPos = 2;
	private int highScore;
	private string key = "HIGH SCORE";
	private Transform playerTrans;
	private int createWallPos = 5;
	private int wall_x;
	// Use this for initialization
	void Start () {
		playerTrans = player.GetComponent<Transform> ();
		scoreText.text = "Score: 0";
		highScore = PlayerPrefs.GetInt (key, 0);
		highScoreText.text = "HighScore: " + highScore.ToString ();
	
	}
	
	// Update is called once per frame
	void Update () {
		float playerHeight = playerTrans.position.y;
		float currentCameraHeight = transform.position.y;
		float newHeight = Mathf.Lerp (currentCameraHeight, playerHeight, 0.5f);

		if (playerHeight > currentCameraHeight) {
			transform.position = new Vector3 (transform.position.x, newHeight, transform.position.z);
		}
		if (playerTrans.position.y >= scoreUpPos) {
			scoreUpPos += 3;
			score += 10;
			scoreText.text = "Score: " + score.ToString ();
			if (score > highScore){
				highScore = score;
				PlayerPrefs.SetInt(key, highScore);
				highScoreText.text = "HighScore: " + highScore.ToString();
			}
			CreateStep();

		}
		if (playerTrans.position.y >= createWallPos) {
			CreateWall ();
			createWallPos += 10;
		}
		if (playerTrans.position.y <= currentCameraHeight - 6) {
			gameOver.Lose ();
			Destroy (player);
		}

	
	}
	void CreateStep(){
		if (Random.Range (0, 10) < 5) {
			wall_x = 2;
		} else {
			wall_x = -2;
		}
		Instantiate (step, new Vector2 (wall_x, scoreUpPos + 2), step.transform.rotation);
	}
	void CreateWall(){
		//Instantiate (wall, new Vector2 (7f, createWallPos + 10), wall.transform.rotation);
	}
}
