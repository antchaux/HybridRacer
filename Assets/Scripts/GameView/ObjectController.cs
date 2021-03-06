﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

	float speed = 20.0f;

	void Start () {

	}

	void Update () {
		transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player Car"){
			FindObjectOfType<EnergyController>().RefillOil();
		}
		Destroy(gameObject);
	}
}
