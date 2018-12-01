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
	public AudioManager audioManager;
	int score;
	string scoreBaseText = "SCORE : ";
	bool gameHasEnded = false;

	void Start () {
		score = 0;
		foreach(Canvas canva in canvas){
			if(canva.name == "CanvasGame") canva.gameObject.SetActive(true);
			else canva.gameObject.SetActive(false);
		}
		flashingText.gameObject.SetActive(false);
		InvokeRepeating("ScoreUpdate", 1.0f, 0.5f);
		//StartCoroutine(BlinkText());
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

	IEnumerator BlinkText(){
		while(true){
			flashingText.gameObject.SetActive(true);
			yield return new WaitForSeconds(.5f);
			flashingText.gameObject.SetActive(false);
			yield return new WaitForSeconds(.5f);
		}
	}

	public void SetBlinking(bool toBlink){
		if(toBlink) StartCoroutine("BlinkText");
		else StopAllCoroutines();
	}

	void ScoreUpdate(){
		if(!gameHasEnded){
			score += 1;
		}
	}
	public void GameOver(){
		if(!gameHasEnded){
			gameHasEnded = true;
			audioManager.mainTheme.Play();
			finalScoreText.text = scoreBaseText + score;

			foreach(Canvas canva in canvas){
				if(canva.name == "CanvasGameOver") canva.gameObject.SetActive(true);
				else canva.gameObject.SetActive(false);
			}
		}
	}

	public void Menu(){
		Time.timeScale = 0;
		menuScoreText.text = scoreBaseText + " " + score;
		audioManager.carSound.Stop();
		audioManager.mainTheme.Play();

		foreach(Canvas canva in canvas){
			if(canva.name == "CanvasPause") canva.gameObject.SetActive(true);
			else canva.gameObject.SetActive(false);
		}
	}

	public void Resume(){
		audioManager.mainTheme.Stop();
		audioManager.carSound.Play();
		Time.timeScale = 1;
		foreach(Canvas canva in canvas){
			if(canva.name == "CanvasPause") canva.gameObject.SetActive(false);
			if(canva.name == "CanvasGame") canva.gameObject.SetActive(true);
		}
	}

	public void Play(){
		audioManager.carSound.Stop();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu(){
		audioManager.carSound.Stop();
		SceneManager.LoadScene("StartMenu");
	}

	public void Exit(){
		Application.Quit();
	}
}
