using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class UIManager : MonoBehaviour {

	public float restartDelay = 1f;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI finalScoreText;
	public TextMeshProUGUI menuScoreText;
	public Button pauseButton;
	public TextMeshProUGUI flashingText;
	public Canvas[] canvas;

	bool blink = false; //TODO : fix blinking
	string tmpflashingText;
	int score;
	string scoreBaseText = "SCORE : ";
	bool gameHasEnded = false;

	void Start () {
		score = 0;
		tmpflashingText = flashingText.text;
		foreach(Canvas canva in canvas){
			if(canva.name == "CanvasGame") canva.gameObject.SetActive(true);
			else canva.gameObject.SetActive(false);
		}

		InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
		StartCoroutine(BlinkText());
	}

	void Update () {
		scoreText.text = scoreBaseText + score;
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
		while(true){
			if(blink){
				Debug.Log("blink");
				//set the Text's text to blank
				flashingText.text= "";
				//display blank text for 0.5 seconds
				yield return new WaitForSeconds(.5f);
				//display “I AM FLASHING TEXT” for the next 0.5 seconds
				flashingText.text= tmpflashingText;
				yield return new WaitForSeconds(.5f);
			}
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
			finalScoreText.text = scoreBaseText + score;

			foreach(Canvas canva in canvas){
				if(canva.name == "CanvasGameOver") canva.gameObject.SetActive(true);
				else canva.gameObject.SetActive(false);
			}
		}
	}

	void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Menu(){
		Time.timeScale = 0;
		menuScoreText.text = scoreBaseText + " " + score;

		foreach(Canvas canva in canvas){
			if(canva.name == "CanvasPause") canva.gameObject.SetActive(true);
			else canva.gameObject.SetActive(false);
		}
	}

	public void Resume(){
		Time.timeScale = 1;
		foreach(Canvas canva in canvas){
			if(canva.name == "CanvasPause") canva.gameObject.SetActive(false);
		}
	}

	public void Play(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu(){
		SceneManager.LoadScene("StartMenu");
	}

	public void Exit(){
		Application.Quit();
	}
}
