using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnLocation : MonoBehaviour {

	public GameObject player1, player2, player3, player4;
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
		player1.GetComponent<Player>().onScoreDoor=false;
		player2.GetComponent<Player>().onScoreDoor=false;
		int number1 = Random.Range(0, leftLocation1.Length);
		int number2 = Random.Range(0, leftLocation2.Length);
		player1.transform.position = new Vector2 (leftLocation1[number1].x, leftLocation1[number1].y);
		player2.transform.position = new Vector2 (leftLocation2[number2].x, leftLocation2[number2].y);
	}

	public void SetRightPlayerLocation (){
		player3.GetComponent<Player>().onScoreDoor=false;
		player4.GetComponent<Player>().onScoreDoor=false;
		int number1 = Random.Range(0, rightLocation1.Length);
		int number2 = Random.Range(0, rightLocation2.Length);
		player3.transform.position = new Vector2 (rightLocation1[number1].x, rightLocation1[number1].y);
		player4.transform.position = new Vector2 (rightLocation2[number2].x, rightLocation2[number2].y);
	}

	public void PlayerIsEnabled(){
		player1.SetActive(true);
		player2.SetActive(true);
		player3.SetActive(true);
		player4.SetActive(true);
	}

	public void PlayerIsDisabled(){
		player1.SetActive(false);
		player2.SetActive(false);
		player3.SetActive(false);
		player4.SetActive(false);
	}
}
