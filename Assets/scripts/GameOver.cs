using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	bool gameOverFlg = false;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOverFlg == true && Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("Title");
		}
	
	}
	public void Lose(){
		gameObject.GetComponent<Text> ().enabled = true;
		gameOverFlg = true;
	}
}
