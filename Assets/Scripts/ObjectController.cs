using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

	public float speed = 15f;

	void Start () {

	}

	void Update () {
		transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(tag == "Oil" && col.gameObject.tag == "Player Car"){
			Destroy(gameObject);
		}
	}
}
