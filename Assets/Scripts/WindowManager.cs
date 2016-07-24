using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WindowManager : MonoBehaviour 
{
	public GameObject tagWindow, deleteWindow;
	RandomizeText rt;
	public MenuTag currentTag;
	public List<GameObject> windows = new List<GameObject>();

	void Start()
	{
		foreach (Transform child in tagWindow.transform) 
		{
			if (child.name == "Title")
				rt = child.GetComponent<RandomizeText> ();
		}
		windows.Add (tagWindow);
		windows.Add (deleteWindow);
	}

	public void openTagWindow ()
	{
		closeAllWindows ();
		rt.switchText ();

		foreach (Transform t in tagWindow.transform) 
		{
			if (t.name == "Coords")
				t.GetComponent<Text> ().text = currentTag.getLatitude()+","+currentTag.getLongitude();
		}

		openWindow (tagWindow);
	}
	public void openDeleteWindow()
	{
		closeAllWindows ();
		deleteWindow.GetComponent<DeleteTag> ().mt = currentTag;
		openWindow (deleteWindow);
	}

	void openWindow(GameObject window)
	{
		CanvasGroup cg = window.GetComponent<CanvasGroup> ();

		cg.alpha = 1;
		cg.interactable = true;
		cg.blocksRaycasts = true;
	}

	public void closeAllWindows()
	{
		foreach(GameObject window in windows)
		{
			CanvasGroup cg = window.GetComponent<CanvasGroup> ();
			cg.alpha = 0;
			cg.interactable = false;
			cg.blocksRaycasts = false;
		}
	}
}
