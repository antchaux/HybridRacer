﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour {

	void Start () {

	}

	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy Car"){
			Destroy(col.gameObject);
		}
	}
}