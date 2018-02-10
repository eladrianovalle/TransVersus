using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public Slider gameLengthSlider, goalsAmountSlider;
	public Text gameLengthAmoutText, goalsAmountText;
	public bool timedGame = true;

	void Update (){
		gameLengthAmoutText.text = gameLengthSlider.value.ToString();
		goalsAmountText.text = goalsAmountSlider.value.ToString();
	}

	public void LoadMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}

	public void SetAsTimedGame (){
		timedGame = true;
	}

	public void SetAsGoalGame (){
		timedGame = false;
	}
}
