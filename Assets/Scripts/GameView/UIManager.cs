using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class UIManager : MonoBehaviour {

	//public GameObject fuelLevel;
	//public GameObject elecLevel;
	bool gameHasEnded = false;
	public float restartDelay = 1f;
	public Text scoreText;
	public TMPro.TextMeshProUGUI flashingText;
	bool blink = false; //TODO : fix blinking
	string tmpflashingText;
	int score;


	void Start () {
		//fuelLevel.SetActive(true);
		score = 0;
		InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
		tmpflashingText = flashingText.text;
		StartCoroutine(BlinkText());
	}

	void Update () {
		scoreText.text = "Score : " + score;
	}

	public void Pause(){
		if(Time.timeScale == 1){
			Time.timeScale = 0;
		}
		else if(Time.timeScale == 0){
			Time.timeScale = 1;
		}
	}

	public IEnumerator BlinkText(){
		while(blink){
			//set the Text's text to blank
			flashingText.text= "";
			//display blank text for 0.5 seconds
			yield return new WaitForSeconds(.5f);
			//display “I AM FLASHING TEXT” for the next 0.5 seconds
			flashingText.text= tmpflashingText;
			yield return new WaitForSeconds(.5f);
		}
	}

	public void setBlinking(bool toBlink){
		blink = toBlink;
	}

	void scoreUpdate(){
		if(!gameHasEnded){
			score += 1;
		}
	}
	public void GameOver(){
		if(!gameHasEnded){
			gameHasEnded = true;
			Pause();
			Debug.Log("GAME OVER");
			//Invoke("Restart", restartDelay);
		}
	}

	void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
