using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour {


	public TextMeshProUGUI blueScore, redScore;

	public int redScoreCount;
	public int blueScoreCount;

	public TextMeshProUGUI announceText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		redScore.text = redScoreCount.ToString();
		blueScore.text = blueScoreCount.ToString();

		if(redScoreCount > blueScoreCount) 
		{
		announceText.text = "RED WINS";
		announceText.color = Color.red;
		} else if (redScoreCount < blueScoreCount) {
		announceText.text = "BLUE WINS";
		announceText.color = Color.blue;
		}else if (redScoreCount == blueScoreCount) {
		announceText.text = "DRAW";
		announceText.color = Color.white;
	}
}
}