using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	Rigidbody2D rb;
	Animator anim;
	public int moveSpeed = 2;
	public LayerMask groundLayer;
	float jumpForce = 1600;
	bool isGrounded;
	private string location;
	private App_Touch.TouchInfo touch;
	private Vector3 touch_pos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		location = "Right";
	
	}
	
	// Update is called once per frame
	void Update () {
		//rb.velocity = new Vector2 (moveSpeed * transform.localScale.x, rb.velocity.y);
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.02f,
			groundLayer);
		if (Ground.stay) {
			isGrounded = false;
		}
		touch = App_Touch.GetTouch ();
		if (touch == App_Touch.TouchInfo.Began && isGrounded) {
			touch_pos = App_Touch.GetTouchPosition();
			if (touch_pos.x > 0) {
				if (location == "Right"){
					Jump ();
				}
				else {
					Right();
				}
			} else {
				if (location == "Left"){
					Jump();
				}
				else{
				Left ();
				}

			}
		}
		Anim ();
	
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Wall") {
			Vector2 tmp = gameObject.transform.localScale;
			tmp.x *= -1;
			gameObject.transform.localScale = tmp;
		}
	}
	void Left(){
		anim.SetTrigger ("Jump");
		rb.AddForce (new Vector2(-360, jumpForce));
		isGrounded = false;
		location = "Left";
	}
	void Right(){
		anim.SetTrigger ("Jump");
		rb.AddForce (new Vector2(360, jumpForce));
		isGrounded = false;
		location = "Right";
	}
	void Jump(){
		anim.SetTrigger ("Jump");
		rb.AddForce (new Vector2 (0, jumpForce));
		isGrounded = false;
	}
	void Anim(){
		float velY = rb.velocity.y;
		anim.SetFloat ("velY", velY);
		anim.SetBool ("isGrounded", isGrounded);
	}

}
