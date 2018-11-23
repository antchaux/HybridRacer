using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject fuelLevel;
	public GameObject elecLevel;
	public Slider slider;


	void Start () {
		//fuelLevel.SetActive(true);
		slider.value = 100;
	}

	void Update () {
		if(slider.value > 0) slider.value -= 1;
	}

	public void Pause(){
		if(Time.timeScale == 1){
			Time.timeScale = 0;
		}
		else if(Time.timeScale == 0){
			Time.timeScale = 1;
		}
	}
}
