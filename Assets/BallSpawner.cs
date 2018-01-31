using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

	public GameObject ballPrefab;

	void Start () {
		int number = Random.Range(0,1);
		if (number == 0) {
			Instantiate(ballPrefab, new Vector3(2.5f, 0f, 0f), Quaternion.identity);
			GameObject ball = Instantiate(ballPrefab, new Vector3(12.6f, 7.91f, 0f), Quaternion.identity) as GameObject;
			ball.transform.parent = transform;

		} else if (number == 1) {
			GameObject ball = Instantiate(ballPrefab, new Vector3(2.6f, 7.91f, 0f), Quaternion.identity) as GameObject;
			ball.transform.parent = transform;

		}
			
	}

}
