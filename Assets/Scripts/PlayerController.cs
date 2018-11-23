using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	private float moveInput;
	private float newX;
	public float roadOffset = 0.7f;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		moveInput = Input.GetAxisRaw("Horizontal");
		newX = rb.position.x + moveInput * (1 + roadOffset);
		if(Mathf.Round(newX) == 0) newX = 0;

		if(Input.GetKeyDown(KeyCode.LeftArrow) && rb.position.x >= 0){
			Debug.Log(newX);
			rb.position = new Vector2(newX, rb.position.y);
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow) && rb.position.x <= 0){
			Debug.Log(newX);
			rb.position = new Vector2(newX, rb.position.y);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy Car"){
			Destroy(gameObject);
		}
	}
}
