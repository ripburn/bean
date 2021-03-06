﻿using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	bool setOff;
	static public bool stay;
	BoxCollider2D colliderOfGround;
	GameObject mainCam;
	// Use this for initialization
	void Start () {
		colliderOfGround = GetComponent<BoxCollider2D> ();
		mainCam = GameObject.FindWithTag ("MainCamera");
		stay = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (setOff) {
			colliderOfGround.enabled = false;
		}
		else {
			colliderOfGround.enabled = true;
		}
		if (transform.position.y <= mainCam.transform.position.y - 6) {
			Destroy (gameObject);
		}
	
	}
	void OnTriggerStay2D (Collider2D col){
		if (col.gameObject.tag == "Player") {
			setOff = true;
			stay = true;
		}
	}

	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag == "Player") {
			setOff = false;
			stay = false;
		}
	}
}
