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

	private float timeLeft = 123f;
//	public TextMeshProUGUI countDownText2;
	public GameObject gameTimer;

	// Use this for initialization
	void Start ()
	{
		SetTimer (123f);
		StartCoroutine ("LoseTime");

	}
	
	// Update is called once per frame
	void Update ()
	{
		
//		if (timeLeft >= 122f) {
//			gameTimer.gameObject.SetActive (false);
//		}

		if (usingTimer) {
			if (timeLeft <= 0) {
				StopCoroutine ("LoseTime");

				//buttonImage.sprite = Resources.Load<Sprite> ("TimesUpR");
				gameTimer.gameObject.SetActive (false);
				//countdownText.text = "Time's Up!";
				//StartCoroutine ("GameOver", 2f);
				//SceneManager.LoadScene ("GameOver");
			}

			if (timeLeft <= 121f) {
				gameTimer.gameObject.SetActive (true);
			}

			if (timeLeft <= 15f) {
				timeText.color = Color.red;
			} else {
				timeText.color = Color.white;
			}
		}

		SetUIText ();
	}

	public void SetTimer (float time)
	{
		if (usingTimer) { return; }

		timeStamp = Time.time + time;
		usingTimer = true;

	}

	public void SetUIText ()
	{
		float timeLeft = timeStamp - Time.time;
		if (timeLeft <= 0) {
			
			FinishAction ();
			return;
		}

//		timeText.text = timeLeft.ToString("f2");
//		float hours;

		float time = timeLeft;
		int minutes = Mathf.FloorToInt(time / 60);
		int seconds = Mathf.FloorToInt(time % 60);
		int milliseconds = Mathf.FloorToInt((time * 100) % 100);

		string formattedTimerText = System.String.Format("{0:0}:{1:00}:{2:00}", minutes, seconds, milliseconds);
		timeText.text = formattedTimerText;
//		timeLeft.ToString("f2");

//
//		GetTimeValues (timeLeft, out hours, out minutes, out seconds, out miniseconds);
//
//		string m = string.Format ("{ 0:00}", miniseconds);
//
//		print ("m = " + m);
//
//		if (hours > 0)
//			timeText.text = string.Format ("{ 0}:{ 1}", hours, minutes);
//		else if (minutes > 0)
//			timeText.text = string.Format ("{ 0}:{ 1}", minutes, seconds);
//		else
//			timeText.text = string.Format ("{ 0}:{ 1}", seconds, m);

	}

	public void GetTimeValues (float time, out float hours, out float minutes, out float seconds, out float miniseconds)
	{
		hours = (int)(time / 3600f);
		minutes = (int)((time - hours * 3600) / 60f);
		seconds = (int)((time - hours * 3600 - minutes * 60));
		miniseconds = (int)((time - hours * 3600 - minutes * 60 - seconds) * 100);
	}

	public void FinishAction ()
	{
		Debug.Log ("Boom");
		timeText.text = "00:00";
		usingTimer = false;

	}

	IEnumerator	LoseTime ()
	{
		{
			while (true) {
				yield return new WaitForSeconds (1f);
				timeLeft--;
			}
		}
	}
}

