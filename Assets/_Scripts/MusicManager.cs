using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public static MusicManager _instance = null;

	public static MusicManager instance { get { return _instance; } }

	public AudioClip redTeamTheme;
	public AudioClip blueTeamTheme;
	public AudioClip bgTheme;

	public AudioClip jumpClip;
	public AudioClip hitClip;
	public AudioClip attackClip;

	private AudioSource[] audioSources;
	private AudioSource nextTrack;
	private AudioSource currentTrack;
	private AudioSource bgTrack;
	private AudioSource sFX;

	private float themeVolume = 0.25f;
	private float smoothing = 0.005f;
	private float volumeMult = 1f;


	void Awake () {
		// make this a singleton
		if (_instance != null && _instance != this) {
			Destroy (this.gameObject);
		} else {
			_instance = this;
			GameObject.DontDestroyOnLoad (this.gameObject);
		}

		// get all children audiosources and assign them to their respective variables
		audioSources = GetComponentsInChildren<AudioSource> ();
		foreach (AudioSource a in audioSources) {
			a.volume = 0;

			if (a.name == "CurrentTrack") {
				currentTrack = a;
			}
			if (a.name == "NextTrack") {
				nextTrack = a;
			}
			if (a.name == "SFX") {
				sFX = a;
				sFX.volume = 1.0f;
			}

			if (a.name == "bgTrack") {
				bgTrack = a;
				bgTrack.volume = 1.0f;
			}
		}
	}

	void Update() {
		CheckForNextClip ();
	}

	public void PlayRedTeamTheme()
	{
		SetClip__NextTrack (redTeamTheme);
	}

	public void PlayBlueTeamTheme()
	{
		SetClip__NextTrack (blueTeamTheme);
	}

	public void Playbgtrack()
	{
		SetClip__NextTrack (bgTheme);
	}

	public void CheckForNextClip(){
		// if new clip added to next track audiosource, crossfade audiosources
		if (nextTrack.clip != null && nextTrack.clip != currentTrack.clip) 
		{
			currentTrack.volume = Mathf.Lerp (currentTrack.volume, 0, Time.time );
			nextTrack.volume = Mathf.Lerp (nextTrack.volume, 1 * volumeMult, Time.time);
			nextTrack.Play ();

			// swap sources once current track volume is inaudible
			if (currentTrack.volume < 0.01) 
			{
				currentTrack.clip = nextTrack.clip;
				SwapSources ();
			}
		}
	}

	public void SwapSources() {
		var tempSource = currentTrack;
		currentTrack = nextTrack;
		nextTrack = tempSource;
	}

	public void SetClip__NextTrack(AudioClip clip){
		if (clip != null) 
		{
			nextTrack.clip = clip;
		} 
		else 
		{
			Debug.LogError ("LOOP clip is null");
		}
	}

	public void SetClip__SFX(AudioClip clip){
		if (clip != null) 
		{
			sFX.clip = clip;
		} 
		else 
		{
			Debug.LogError ("SFX clip is null");
		}
	}

	public void PlaySFX() {
		sFX.Play ();
	}

	public void PlaySFX(float volume) {
		sFX.volume = volume;
		sFX.Play ();
	}

	public void PlaySFX(AudioClip clip) {
		SetClip__SFX (clip);
		sFX.Play ();
	}



	public void FadeInTheme() {
		nextTrack.volume = Mathf.Lerp (nextTrack.volume, themeVolume, Time.time * smoothing);
		currentTrack.volume = Mathf.Lerp (currentTrack.volume, 1, Time.time * smoothing);
	}

	public void FadeOutTheme() {
		nextTrack.volume = Mathf.Lerp (nextTrack.volume, 0, Time.time);
	}

//	public void TestCrossfade_2() {
//		nextTrack.volume = Mathf.Lerp (nextTrack.volume, 0, Time.time);
//		nextTrack.clip = testClip_2;
//	}

	public void SetAllVolume(float volume) {
		this.volumeMult = volume;
	}
}