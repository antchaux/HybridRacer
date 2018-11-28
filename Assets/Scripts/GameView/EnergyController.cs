using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyController : MonoBehaviour {

	public Slider oil;
	public Slider electricity;
	public int maxOilValue = 100;
	public int maxElectricityValue = 100;
	public int oilRefillValue = 25;
	bool usingOil = true;
	bool transformOil = false;

	void Start(){
		oil.value = maxOilValue;
		electricity.value = maxElectricityValue;
		InvokeRepeating("DecreaseOil", 1.0f, 0.5f);
	}

	void Update(){
		// Use Oil
		if(Input.GetKey(KeyCode.A) && !usingOil){
			CancelInvoke("DecreaseElectricity");
			InvokeRepeating("DecreaseOil", 0.0f, 0.5f);
			usingOil = true;
		}

		// Use Electricity
		else if(Input.GetKey(KeyCode.S) && usingOil){
			CancelInvoke("DecreaseOil");
			InvokeRepeating("DecreaseElectricity", 0.0f, 0.5f);
			usingOil = false;
		}

		//Refill Electricity with Oil (Only when using Oil)
		else if(Input.GetKey(KeyCode.D) && usingOil){
			if(!transformOil){
				InvokeRepeating("RefillElectricity", 0.0f, 0.5f);
				transformOil = true;
			}
			else{
				CancelInvoke("RefillElectricity");
				transformOil = false;
			}
		}
	}

	void DecreaseOil(){
		if(oil.value > 0){
			oil.value -= 1;
		}
		else{
			FindObjectOfType<UIManager>().GameOver();
		}
	}

	public void RefillOil(){
		if(oil.value < (maxOilValue - oilRefillValue)){
			oil.value += oilRefillValue;
		}
		else{
			oil.value = maxOilValue;
		}
	}

	void DecreaseElectricity(){
		if(electricity.value > 0){
			electricity.value -= 2;
		}
		else{
			FindObjectOfType<UIManager>().GameOver();
		}
	}

	void RefillElectricity(){
		if(electricity.value < maxElectricityValue){
			DecreaseOil();
			DecreaseOil();
			electricity.value += 1;
		}
	}
}
