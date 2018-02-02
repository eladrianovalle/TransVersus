using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour {

	public GameObject leftPortalGreen, leftPortalRed, leftPortalBlue, rightPortalGreen, rightPortalRed, rightPortalBlue;

	private Vector2 leftLocation1 = new Vector2 (-2.29f, 26.97f);
	private Vector2 leftLocation2 = new Vector2 (-2.29f, 20.93f);
	private Vector2 leftLocation3 = new Vector2 (-2.29f, 14.87f);
	private Vector2 rightLocation1 = new Vector2 (1.9f, 26.97f);
	private Vector2 rightLocation2 = new Vector2 (1.9f, 20.93f);
	private Vector2 rightLocation3 = new Vector2 (1.9f, 14.87f);

	// Use this for initialization
	void Awake () {
		SetPortalLocation();
	}

	public void SetPortalLocation(){
		int leftNumber = Random.Range(0,300);
		if (leftNumber < 100) {
			leftPortalGreen.transform.position = leftLocation1;
			leftPortalRed.transform.position = leftLocation2;
			leftPortalBlue.transform.position = leftLocation3;
		} else if (leftNumber > 200) {
			leftPortalGreen.transform.position = leftLocation2;
			leftPortalRed.transform.position = leftLocation3;
			leftPortalBlue.transform.position = leftLocation1;
		} else {
			leftPortalGreen.transform.position = leftLocation3;
			leftPortalRed.transform.position = leftLocation1;
			leftPortalBlue.transform.position = leftLocation2;
		}

		int rightNumber = Random.Range(0,300);
		if (rightNumber < 100) {
			rightPortalGreen.transform.position = rightLocation1;
			rightPortalRed.transform.position = rightLocation2;
			rightPortalBlue.transform.position = rightLocation3;
		} else if (rightNumber > 200) {
			rightPortalGreen.transform.position = rightLocation2;
			rightPortalRed.transform.position = rightLocation3;
			rightPortalBlue.transform.position = rightLocation1;
		} else {
			rightPortalGreen.transform.position = rightLocation3;
			rightPortalRed.transform.position = rightLocation1;
			rightPortalBlue.transform.position = rightLocation2;
		}
	}
}
