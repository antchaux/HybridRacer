using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour {

	public GameObject[] cars;
	public GameObject[] energies;
	public float offset = 0.7f;
	public float delayTimer = 0.5f;
	int objectSelected;

	void Start () {
		InvokeRepeating("Spawner", delayTimer, delayTimer);
	}

	void Spawner(){
		try{
			int oilValue = FindObjectOfType<EnergyController>().getOilValue();
			if(oilValue < 5) getObjectType(5);
			else if(oilValue < 10) getObjectType(10);
			else if(oilValue < 15) getObjectType(15);
			else getObjectType(20);
		}
		catch (Exception e)
		{
			getObjectType(-1);
		}
	}

	void getObjectType(int randomMax){
		if(randomMax > 0 && UnityEngine.Random.Range(0, randomMax) == 0){
			SpawnObject(energies);
		}
		else{
			SpawnObject(cars);
		}
	}

	public void SpawnObject(GameObject[] obj){
		Vector3 objPos = new Vector3(UnityEngine.Random.Range(-1,2) * (1 + offset), transform.position.y, 0);
		objectSelected = UnityEngine.Random.Range(0,obj.Length);
		Instantiate(obj[objectSelected], objPos, transform.rotation);
	}
}
