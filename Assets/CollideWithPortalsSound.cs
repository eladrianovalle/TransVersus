using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPortalsSound : MonoBehaviour {


	public AudioSource audio;
	// Use this for initialization

	// Update is called once per frame

	void OnTriggerEnter2D (Collider2D other) {

	audio.Play ();
		
	}
}
