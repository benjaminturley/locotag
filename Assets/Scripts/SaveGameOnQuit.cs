using UnityEngine;
using UnityEditor;
using System.Collections;

public class SaveGameOnQuit : MonoBehaviour 
{
	public MenuObject menuObject;

	void OnApplicationQuit()
	{
		saveGame ();
	}

	void OnApplicationPause(bool isPaused)
	{
		if (isPaused)
			saveGame ();
	}

	void saveGame()
	{
		AssetDatabase.Refresh ();
		EditorUtility.SetDirty (menuObject);
		AssetDatabase.SaveAssets ();
	}
}
