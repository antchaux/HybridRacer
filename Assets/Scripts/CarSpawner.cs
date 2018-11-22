using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public GameObject car;
	public float offset = 0.7f;
	public float delayTimer = 0.5f;
	float timer;
	void Start () {
		timer = delayTimer;
	}

	void Update () {

		timer -= Time.deltaTime;
		if(timer <= 0){
			Vector3 carPos = new Vector3(Random.Range(-1,2) * (1 + offset), transform.position.y, 0);
			Instantiate(car, carPos, transform.rotation);
			timer = delayTimer;
		}
	}
}
