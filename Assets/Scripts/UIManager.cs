using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	//public GameObject fuelLevel;
	//public GameObject elecLevel;
	bool gameHasEnded = false;
	public float restartDelay = 1f;
	public Text scoreText;
	int score;


	void Start () {
		//fuelLevel.SetActive(true);
		score = 0;
		InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
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
