using UnityEngine;
using System.Collections;

public class SendToWindowManager : MonoBehaviour 
{
	WindowManager wm;
	public MenuTag mt;

	void Start()
	{
		wm = GameObject.Find ("_GameManager").GetComponent<WindowManager> ();
	}

	public void send()
	{
		wm.currentTag = mt;
		wm.openTagWindow ();
	}
}
