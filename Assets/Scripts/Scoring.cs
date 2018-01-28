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
		announceText.text = "Red Wins";
		announceText.color = Color.red;
		} else if (redScoreCount < blueScoreCount) {
		announceText.text = "Blue Wins";
		announceText.color = Color.blue;
		}else if (redScoreCount == blueScoreCount) {
		announceText.text = "Draw";
		announceText.color = Color.white;
	}
}
}