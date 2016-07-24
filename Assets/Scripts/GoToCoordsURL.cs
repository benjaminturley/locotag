using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoToCoordsURL : MonoBehaviour 
{
	string coords;

	public void gotoURL()
	{
		coords = transform.parent.GetChild(2).GetComponent<Text> ().text;

		#if UNITY_ANDROID
			Application.OpenURL ("geo:"+coords+"?q="+coords);
		#else
			Application.OpenURL ("http://maps.apple.com/?ll="+coords);
		#endif
	}
}
