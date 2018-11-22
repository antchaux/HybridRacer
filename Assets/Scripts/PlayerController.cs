using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	private float moveInput;
	public float roadOffset;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		moveInput = Input.GetAxisRaw("Horizontal");
		if(Input.GetKeyDown(KeyCode.LeftArrow) && rb.position.x >= 0){
			Debug.Log(moveInput);
			rb.position = new Vector2(rb.position.x + moveInput - roadOffset, rb.position.y);
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow) && rb.position.x <= 0){
			Debug.Log(moveInput);
			rb.position = new Vector2(rb.position.x + moveInput + roadOffset, rb.position.y);
		}
	}
}
