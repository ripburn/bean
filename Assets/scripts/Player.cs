using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	Rigidbody2D rb;
	Animator anim;
	public int moveSpeed = 2;
	public LayerMask groundLayer;
	float jumpForce = 500;
	bool isGrounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (moveSpeed * transform.localScale.x, rb.velocity.y);
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.1f,
			groundLayer);
		if (isGrounded && Input.GetButtonDown ("Jump")) {
			Jump ();
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
	void Jump(){
		anim.SetTrigger ("Jump");
		rb.AddForce (Vector2.up * jumpForce);
		isGrounded = false;
	}
	void Anim(){
		float velY = rb.velocity.y;
		anim.SetFloat ("velY", velY);
		anim.SetBool ("isGrounded", isGrounded);
	}

}
