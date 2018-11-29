using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyController : MonoBehaviour {

	//public Slider oil;
	//public Slider electricity;
	//public int maxOilValue = 10;
	public Image[] OilImage;
	public Image[] ElecImage;
	//public int maxElectricityValue = 100;
	public int oilRefillValue;
	int oilValue;
	int elecValue;
	bool usingOil;

	void Start(){
		oilValue = OilImage.Length - 1;
		elecValue = ElecImage.Length - 1;
		for(int i = 0; i < OilImage.Length; i++){
			OilImage[i].enabled = true;
		}

		usingOil = true;

		InvokeRepeating("DecreaseOil", 2.0f, 2.0f);
	}

	void Update(){
		// Use Oil
		if(Input.GetKeyDown(KeyCode.A) && !usingOil){
			CancelInvoke("DecreaseElectricity");
			InvokeRepeating("DecreaseOil", 2.0f, 2.0f);
			usingOil = true;
		}

		// Use Electricity
		else if(Input.GetKeyDown(KeyCode.S) && usingOil){
			CancelInvoke("DecreaseOil");
			InvokeRepeating("DecreaseElectricity", 1.0f, 1.0f);
			usingOil = false;
		}

		//Refill Electricity with Oil (Only when using Oil)
		else if(Input.GetKeyDown(KeyCode.D) && usingOil && !IsInvoking("RefillElectricity")){
			InvokeRepeating("RefillElectricity", 2.0f, 2.0f);
			FindObjectOfType<UIManager>().setBlinking(true);
		}

		//Stop electricity refill
		else if(Input.GetKeyDown(KeyCode.D) && usingOil && IsInvoking("RefillElectricity")){
			CancelInvoke("RefillElectricity");
			FindObjectOfType<UIManager>().setBlinking(false);
		}
	}

	void DecreaseOil(){
		if(oilValue > 0){
			OilImage[oilValue].enabled = false;
			oilValue -= 1;
		}
		else{
			FindObjectOfType<UIManager>().GameOver();
		}
	}

	public void RefillOil(){
		if(oilValue < (OilImage.Length - oilRefillValue - 1)){
			for(int i = oilValue; i < oilValue + oilRefillValue + 1; i++){
				OilImage[i].enabled = true;
			}
			oilValue += oilRefillValue;
		}
		else{
			for(int i = oilValue; i < OilImage.Length; i++){
				OilImage[i].enabled = true;
			}
			oilValue = OilImage.Length - 1;
		}
	}

	void DecreaseElectricity(){
		if(elecValue > 0){
			ElecImage[elecValue].enabled = false;
			elecValue -= 1;
		}
		else{
			FindObjectOfType<UIManager>().GameOver();
		}
	}

	void RefillElectricity(){
		if(elecValue < ElecImage.Length - 1){
			DecreaseOil();
			DecreaseOil();
			elecValue += 1;
			ElecImage[elecValue].enabled = true;
		}
		else{
			CancelInvoke("RefillElectricity");
		}
	}
}
