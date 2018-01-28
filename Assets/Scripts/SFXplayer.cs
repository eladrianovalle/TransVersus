using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXplayer : MonoBehaviour {

	public AudioClip jumpTrack;
	public AudioClip hitTrack;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayHitFX()
	{
		MusicManager.instance.PlaySFX (hitTrack);
	}


	public void PlayjumpFX()
		{
		MusicManager.instance.PlaySFX (jumpTrack);
		
	
	}
}
