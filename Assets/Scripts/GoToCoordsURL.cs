using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoToCoordsURL : MonoBehaviour 
{
	string coords;

	public void gotoURL()
	{
		coords = transform.parent.GetChild(1).GetComponent<Text> ().text;

		#if UNITY_ANDROID
			Application.OpenURL ("geo:"+coords+"?q=LocoTag");
		#else
			Application.OpenURL ("http://maps.apple.com/?ll="+coords);
		#endif
	}
}
