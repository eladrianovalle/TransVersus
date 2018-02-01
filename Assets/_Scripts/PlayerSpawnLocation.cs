using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnLocation : MonoBehaviour {

	public GameObject Player1, Player2, Player3, Player4;
	public Vector2[] leftLocation1 = new Vector2[8];
	public Vector2[] leftLocation2 = new Vector2[8];
	public Vector2[] rightLocation1 = new Vector2[10];
	public Vector2[] rightLocation2 = new Vector2[10];


	// Use this for initialization
	void Start () {
		SetLeftPlayerLocation();
		SetRightPlayerLocation();
	}

	public void SetLeftPlayerLocation (){
		int number1 = Random.Range(0, leftLocation1.Length);
		int number2 = Random.Range(0, leftLocation2.Length);
		Player1.transform.position = new Vector2 (leftLocation1[number1].x, leftLocation1[number1].y);
		Player2.transform.position = new Vector2 (leftLocation2[number2].x, leftLocation2[number2].y);
	}

	public void SetRightPlayerLocation (){
		int number1 = Random.Range(0, rightLocation1.Length);
		int number2 = Random.Range(0, rightLocation2.Length);
		Player3.transform.position = new Vector2 (rightLocation1[number1].x, rightLocation1[number1].y);
		Player4.transform.position = new Vector2 (rightLocation2[number2].x, rightLocation2[number2].y);
	}


}
