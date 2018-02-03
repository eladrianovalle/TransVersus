using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public static MusicManager _instance = null;

	public static MusicManager instance { get { return _instance; } }

	[Header("Themes")]
	public AudioClip redTeamTheme;
	public AudioClip blueTeamTheme;
	public AudioClip bgTheme;
	public AudioClip bgFadedTheme;

	[Header("SFX")]
	public AudioClip jumpClip;
	public AudioClip hitClip;
	public AudioClip attackClip;

	private AudioSource[] audioSources;
	private AudioSource blueTrack;
	private AudioSource redTrack;
	private AudioSource bgTrack;
	private AudioSource bgFilteredTrack;
	private AudioSource sFX;

	private float themeVolume = 0f;
	private float filteredThemeVolume = 0f;
	private float redTrackVolume = 0f;
	private float blueTrackVolume = 0f;


	private float smoothing = 0.005f;
//	private float volumeMult = 1f;


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

			if (a.name == "RedTrack") 
			{
				redTrack = a;
				redTrack.clip = redTeamTheme;
			}
			if (a.name == "BlueTrack") 
			{
				blueTrack = a;
				blueTrack.clip = blueTeamTheme;
			}
			if (a.name == "bgTrack") 
			{
				bgTrack = a;
				bgTrack.clip = bgTheme;
			}
			if (a.name == "bgFilteredTrack")
			{
				bgFilteredTrack = a;
				bgFilteredTrack.clip = bgFadedTheme;
			}
			if (a.name == "SFX") 
			{
				sFX = a;
				sFX.volume = 1.0f;
			}
		}
	}

	void Start()
	{
		themeVolume = 0.5f;
		foreach (AudioSource a in audioSources) {
			a.Play ();
		}
	}

	void Update() 
	{
		redTrack.volume = Mathf.Lerp (redTrack.volume, redTrackVolume, Time.time * smoothing);
		blueTrack.volume = Mathf.Lerp (blueTrack.volume, blueTrackVolume, Time.time * smoothing);
		bgTrack.volume = Mathf.Lerp (bgTrack.volume, themeVolume, Time.time * smoothing);
		bgFilteredTrack.volume = Mathf.Lerp (bgFilteredTrack.volume, filteredThemeVolume, Time.time * smoothing);
	}

	public void PlayRedTeamTheme()
	{
		themeVolume = 0.5f;
		filteredThemeVolume = 0f;
		redTrackVolume = 1f;
		blueTrackVolume = 0f;
	}

	public void PlayBlueTeamTheme()
	{
		themeVolume = 0.5f;
		filteredThemeVolume = 0f;
		redTrackVolume = 0f;
		blueTrackVolume = 1f;
	}

	public void PlayBGtrack()
	{		
		themeVolume = 0.5f;
		filteredThemeVolume = 0f;
		redTrackVolume = 0f;
		blueTrackVolume = 0f;
	}

	public void PlayFilteredBGtrack()
	{
		themeVolume = 0f;
		filteredThemeVolume = 1f;
		redTrackVolume = 0f;
		blueTrackVolume = 0f;
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
		bgTrack.volume = Mathf.Lerp (bgTrack.volume, themeVolume, Time.time * smoothing);
	}

	public void FadeOutMusic() {
		foreach (AudioSource a in audioSources) {
			a.volume = Mathf.Lerp (a.volume, 0, Time.time * smoothing);
		}
	}
}