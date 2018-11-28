using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour {

	public GameObject[] cars;
	public GameObject[] energies;
	public float offset = 0.7f;
	public float delayTimer = 0.5f;
	public Slider oil;
	int objectSelected;

	void Start () {
		InvokeRepeating("SpawnObject", delayTimer, delayTimer);
	}

	void Update () {
	}

	void SpawnObject(){
		int getOilChances = (int) oil.value; //TODO improve logic of spawing oil cans
		if(Random.Range(0, getOilChances) == 0){
			SpawnObject(energies);
		}
		else{
			SpawnObject(cars);
		}
	}

	public void SpawnObject(GameObject[] obj){
		Vector3 objPos = new Vector3(Random.Range(-1,2) * (1 + offset), transform.position.y, 0);
		objectSelected = Random.Range(0,obj.Length);
		Instantiate(obj[objectSelected], objPos, transform.rotation);
	}
}
