using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public Slider gameLengthSlider, goalsAmountSlider;
	public Text gameLengthAmoutText, goalsAmountText;
	public LevelManager levelManager;

	void Start () {
		LevelManager.timedGame=true;
	}

	void Update (){
		gameLengthAmoutText.text = gameLengthSlider.value.ToString();
		goalsAmountText.text = goalsAmountSlider.value.ToString();
	}

	public void LoadMainMenu(){
		if (LevelManager.timedGame == true) {
			levelManager.SetGameLength(gameLengthSlider.value);
			Debug.Log ("Timed game set to " + LevelManager.gameLenght + " Slider = " + gameLengthSlider.value);
		} else {
			levelManager.SetGoalAmount(goalsAmountSlider.value);
			Debug.Log ("GOALS GAME set to " + LevelManager.goalAmount + " Goal slider = " + goalsAmountSlider.value);
		}
		SceneManager.LoadScene("MainMenu");
	}

	public void SetAsTimedGame (){
		LevelManager.timedGame = true;
	}

	public void SetAsGoalGame (){
		LevelManager.timedGame = false;
	}
}
