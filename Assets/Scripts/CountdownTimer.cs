using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour {


	//public string levelToLoad;
	private float timer;
	//private Text timerSeconds;
//	public TextMeshProUGUI countDownText;
	public Text countDownText;
	public AudioSource audioSource;






	[SerializeField] private GameObject CountDownCanvas;


	void Awake() {
		SetTimer(3.75f);
//		CountDownCanvas.gameObject.SetActive (true);
	}

	void Start () {
		//m_textMeshPro = gameObject.AddComponent<TextMeshPro>();
		//timerSeconds = GetComponent<TextMeshPro>();
		//timerSeconds = GetComponent<Text>();
//		countDownText = GetComponent<TextMeshProUGUI>();
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	if (audioSource != null)
	{
			audioSource.Play();

	}

		timer -= Time.unscaledDeltaTime;
		//timerSeconds.text = timer.ToString("f0");
		countDownText.text = timer.ToString("f0");
//		print ("timer = " + timer);
		if (timer <= 0.5f)
		{
			CountDownCanvas.gameObject.SetActive (false);
			Time.timeScale = 1f;
		}
	}

	public void SetTimer(float time){
		timer = time;
		print ("timer set to 3");
	}
}

