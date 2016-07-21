using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisableCanvasGroup : MonoBehaviour 
{
	CanvasGroup cg;

	void Start()
	{
		cg = transform.parent.GetComponent<CanvasGroup> ();
	}
	public void doDisable()
	{
		cg.alpha = 0;
		cg.interactable = false;
		cg.blocksRaycasts = false;
	}
}
