using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	private float moveInput;
	public float leftPosition = -1.7f;
	public float rightPosition = 1.7f;
	public float roadOffset = 0.7f;
	private float startY;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		startY = rb.position.y;
	}

	void Update(){
		moveCar();
		/*/moveInput = Input.GetAxisRaw("Horizontal");
		newX = rb.position.x + moveInput * (1 + roadOffset);
		if(Mathf.Round(newX) == 0) newX = 0;

		if(Input.GetKeyDown(KeyCode.LeftArrow) && rb.position.x >= 0){
			rb.position = new Vector2(newX, rb.position.y);
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow) && rb.position.x <= 0){
			rb.position = new Vector2(newX, rb.position.y);
		}*/
	}

	void moveCar(){ //TODO fix issue of car not on the right place when moving
		Debug.Log(rb.position);
		moveInput = Input.GetAxisRaw("Horizontal");

		if(Input.GetKeyDown(KeyCode.LeftArrow) && rb.position.x >= 0){
			if(rb.position.x == rightPosition){
				rb.position = new Vector2(0f, startY);
			}
			else{
				rb.position = new Vector2(leftPosition, startY);
			}
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow) && rb.position.x <= 0){
			if(rb.position.x == leftPosition){
				rb.position = new Vector2(0f, startY);
			}
			else{
				rb.position = new Vector2(rightPosition, startY);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy Car"){
			Destroy(gameObject);
			FindObjectOfType<UIManager>().GameOver();
		}
		else if(col.gameObject.tag == "Oil"){
			FindObjectOfType<EnergyController>().RefillOil();
		}
	}
}
