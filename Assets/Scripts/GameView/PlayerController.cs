using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	public float leftPosition = -1.7f;
	public float rightPosition = 1.7f;
	public float roadOffset = 0.7f;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		moveCar();
	}

	void moveCar(){
		if(Input.GetKeyDown(KeyCode.LeftArrow) && rb.position.x >= 0){
			if(rb.position.x == rightPosition){
				rb.position = new Vector2(0f, rb.position.y);
			}
			else{
				rb.position = new Vector2(leftPosition, rb.position.y);
			}
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow) && rb.position.x <= 0){
			if(rb.position.x == leftPosition){
				rb.position = new Vector2(0f, rb.position.y);
			}
			else{
				rb.position = new Vector2(rightPosition, rb.position.y);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy Car"){
			Destroy(gameObject);
			FindObjectOfType<UIManager>().GameOver();
		}
	}
}
