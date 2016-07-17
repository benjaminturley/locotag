using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInCanvasGroup : MonoBehaviour 
{
	public float speed = 1f;
	public float delay;
	private float endAlpha;
	private CanvasGroup cg;

	void Start()
	{
		cg = GetComponent<CanvasGroup>();
		endAlpha = cg.alpha;
		cg.alpha = 0;

		StartCoroutine ("checkDelay");
	}

	void Update () 
	{
		if(delay == 0)
			cg.alpha = Mathf.Lerp(cg.alpha, endAlpha, Time.deltaTime * speed);
	}

	IEnumerator checkDelay()
	{
		yield return new WaitForSeconds (delay);
		delay = 0;
	}
}
