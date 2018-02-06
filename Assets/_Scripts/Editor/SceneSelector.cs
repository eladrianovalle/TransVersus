using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneShortcut {

	const string MENU = "*(  =^ .^=)/";
	const string GAMESCENES = MENU + "Game Scenes/";
	const string MENUS = MENU + "Menus/";
	const string TESTSCENES = MENU + "Test Scenes/";


	[MenuItem (MENUS + "Splash Screen")]
	static void SplashScreen ()
	{
		LoadScene ("Splash");
	}

	[MenuItem (MENUS + "Main Menu")]
	static void MainMenu ()
	{
		LoadScene ("MainMenu");
	}

	[MenuItem (GAMESCENES + "Game")]
	static void Game ()
	{
		LoadScene ("Level1");
	}

	[MenuItem (TESTSCENES + "Adriano Test")]
	static void AdrianoTest ()
	{
		LoadScene ("Adriano_Work");
	}


	static void LoadScene (string sceneName)
	{
		bool goOn = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo ();
		if (!goOn)
			return;
		var scenePath = GetSceneFromBuildSettings (sceneName);
		if (!string.IsNullOrEmpty (scenePath))
		{
			EditorSceneManager.OpenScene (scenePath);
		} else
		{
			Debug.Log ("Can't find scene " + sceneName);
		}
	}

	static string GetSceneFromBuildSettings (string name)
	{
		name += ".unity";
		var scenes = EditorBuildSettings.scenes;
		for (int i = 0; i < scenes.Length; i++)
		{
			if (scenes [i].path.EndsWith (name))
			{
				return scenes [i].path;
			}
		}
		return string.Empty;
	}

}
