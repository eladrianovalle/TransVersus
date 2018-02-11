using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MasterGameTimer : MonoBehaviour
{

	public TextMeshProUGUI timeText;
	public float timeStamp;
	public bool usingTimer = false;
	public LevelManager levelManager;
	private float time;
	public GameObject gameTimer;
	public GameObject gameOverPopUp;
	public MusicManager musicManager;


	void Awake () {
		if (LevelManager.timedGame==true) {
			time = (LevelManager.gameLenght * 60f);
			SetTimer(time);
			StartCoroutine ("LoseTime");
			gameTimer.gameObject.SetActive (true);
			Debug.Log ("Timed game set to " + time);
		} else {
			gameTimer.SetActive(false);
		}
	}



	void Update () {


		if (usingTimer) {
			if (time <= 0) {
				StopCoroutine ("LoseTime");
				gameTimer.gameObject.SetActive (false);
			}


			if (time <= 15f) {
				timeText.color = Color.red;
			} else {
				timeText.color = Color.white;
			}
		}


		SetUIText ();
	}

	public void SetTimer (float time) {
		if (usingTimer) { return; }

		timeStamp = Time.time + time;
		usingTimer = true;

	}

	public void SetUIText () {
		float timeLeft = timeStamp - Time.time;
		if (timeLeft <= 0 && LevelManager.timedGame==true) {
			FinishAction ();
			return;
		}


		float time = timeLeft;
		int minutes = Mathf.FloorToInt(time / 60);
		int seconds = Mathf.FloorToInt(time % 60);
		int milliseconds = Mathf.FloorToInt((time * 100) % 100);

		string formattedTimerText = System.String.Format("{0:0}:{1:00}:{2:00}", minutes, seconds, milliseconds);
		timeText.text = formattedTimerText;


	}

	public void GetTimeValues (float time, out float hours, out float minutes, out float seconds, out float miniseconds)
	{
		hours = (int)(time / 3600f);
		minutes = (int)((time - hours * 3600) / 60f);
		seconds = (int)((time - hours * 3600 - minutes * 60));
		miniseconds = (int)((time - hours * 3600 - minutes * 60 - seconds) * 100);
	}

	public void FinishAction () {
		timeText.text = "00:00";
		gameOverPopUp.SetActive(true);
		usingTimer = false;
		musicManager.FadeOutMusic();
	}

	IEnumerator	LoseTime ()
	{
		{
			while (true) {
				yield return new WaitForSeconds (1f);
				time--;
			}
		}
	}
}

