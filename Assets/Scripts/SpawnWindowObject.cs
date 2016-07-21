using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnWindowObject : MonoBehaviour 
{
	public GameObject window;

	void Start()
	{
		window = GameObject.Find ("TagWindow");
	}

	public void spawnWindow()
	{
		string myCoords = "";

		foreach (Transform t in transform) 
		{
			if (t.name == "Latitude")
				myCoords = (t.GetComponent<Text> ().text + ", "+ myCoords);
			if(t.name == "Longitude")
				myCoords = (myCoords + t.GetComponent<Text> ().text);
		}

		CanvasGroup cg = window.GetComponent<CanvasGroup> ();

		if (cg.alpha != 1) 
		{
			cg.alpha = 1;
			cg.interactable = true;
			cg.blocksRaycasts = true;
		}
		
		foreach(Transform child in window.transform)
		{
			if (child.name == "Coords")
				child.GetComponent<Text> ().text = myCoords;
		}
	}
}
