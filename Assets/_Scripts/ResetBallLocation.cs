using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallLocation : MonoBehaviour {

	public BallSpawner ballSpawner;

	void OnTriggerEnter2D(Collider2D other) {
		ballSpawner.SetBallLocation();
    }
}
