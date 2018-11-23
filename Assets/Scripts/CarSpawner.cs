using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public GameObject[] cars;
	public float offset = 0.7f;
	public float delayTimer = 0.5f;
	float timer;
	int carSelected;
	void Start () {
		timer = delayTimer;
	}

	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0){
			Vector3 carPos = new Vector3(Random.Range(-1,2) * (1 + offset), transform.position.y, 0);
			carSelected = Random.Range(0,6);
			Instantiate(cars[carSelected], carPos, transform.rotation);
			timer = delayTimer;
		}
	}
}
