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
			useOil();
		}

		// Use Electricity
		else if(Input.GetKeyDown(KeyCode.S) && usingOil){
			useElec();
		}

		//Refill Electricity with Oil (Only when using Oil)
		else if(Input.GetKeyDown(KeyCode.D) && usingOil && !IsInvoking("RefillElectricity")){
			Debug.Log("start blinking");
			FindObjectOfType<UIManager>().setBlinking(true);
			InvokeRepeating("RefillElectricity", 2.0f, 2.0f);
		}

		//Stop electricity refill
		else if(Input.GetKeyDown(KeyCode.D) && usingOil && IsInvoking("RefillElectricity")){
			FindObjectOfType<UIManager>().setBlinking(false);
			CancelInvoke("RefillElectricity");
		}
	}

	void useOil(){
		CancelInvoke("DecreaseElectricity");
		InvokeRepeating("DecreaseOil", 2.0f, 2.0f);
		usingOil = true;
	}

	void useElec(){
		if(IsInvoking("RefillElectricity")){
			CancelInvoke("RefillElectricity");
			FindObjectOfType<UIManager>().setBlinking(false);
		}
		CancelInvoke("DecreaseOil");
		InvokeRepeating("DecreaseElectricity", 1.0f, 1.0f);
		usingOil = false;
	}

	void DecreaseOil(){
		OilImage[oilValue].enabled = false;
		if(oilValue > 0){
			oilValue -= 1;
		}
		else if(elecValue > 0){
			useElec();
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
		ElecImage[elecValue].enabled = false;
		if(elecValue > 0){
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
		else if(oilValue > 0){
			useOil();
		}
		else{
			CancelInvoke("RefillElectricity");
		}
	}

	public int getOilValue(){
		return oilValue;
	}

	public int getElecValue(){
		return elecValue;
	}
}
