using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

	public Ball ball;
	public Vector2[] spawnLocation = new Vector2[17];

	void Awake () {
		SetBallLocation();
	}

	public void SetBallLocation() {
		int randomNumber = Random.Range (0,spawnLocation.Length);
		float x = spawnLocation[randomNumber].x;
		float y = spawnLocation[randomNumber].y;
		ball.transform.position = new Vector2(x,y);
		print ("Ball location = " + x + " , " + y);
	}
}
