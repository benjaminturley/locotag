using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class DisplayAds : MonoBehaviour
{
	public int displayAdSeconds = 65;

	void Start () 
	{
		#if UNITY_IOS
			Advertisement.Initialize ("122782");
		#elif UNITY_ANDROID
			Advertisement.Initialize ("122781");
		#endif

		resetAdTimer ();
	}

	void Update()
	{
		if (Advertisement.isShowing)
			resetAdTimer ();
	}

	void resetAdTimer()
	{
		CancelInvoke ();
		InvokeRepeating ("invokeAd", displayAdSeconds, displayAdSeconds);
	}
	
	void invokeAd ()
	{
		if (Advertisement.IsReady ())
			Advertisement.Show ();
	}
}
