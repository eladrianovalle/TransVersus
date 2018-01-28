using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Splash : MonoBehaviour {   	public string sceneToLoad; // scene name which will be loaded 	public TextMeshProUGUI loadingText; 	public float delay = 0.25f; // delay between adding another dot   	private int counter = 0; 	private float timeAccu = 0f; 	private string loadingString; // get string from loadingText; we will add dots to it   	void Start () { 		loadingString = loadingText.text; 		StartCoroutine (LoadGame ()); // start loading coroutine 	}   	void Update () { 		timeAccu += Time.deltaTime; 		if (timeAccu >= delay) { // if delay passed 			loadingText.text = loadingString.PadRight (loadingString.Length + counter % 4, '.'); // add another dot 			counter++; 			timeAccu = 0f; 		} 	}   	private IEnumerator LoadGame () { 		// here is dummy waint time to simulate loading heavy scene; remove it in target application! 		yield return new WaitForSeconds (3f); 		AsyncOperation async = SceneManager.LoadSceneAsync (sceneToLoad); // load scene by its name asychronically 		while (!async.isDone) { // wait until scene loading is done 			yield return null; // wait and let to update splash screen 		} 	} } 