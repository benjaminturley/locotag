using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TagUI : MonoBehaviour 
{
	public string timeString;
	public string dateString;
	public string shortDateString;
	public float longitude;
	public float latitude;

	public Text timeText;
	public Text dateText;
	public Text coordsText;
	public Text pullText;

	void Start()
	{
		if(Input.location.isEnabledByUser)
			Input.location.Start ();
	}

	void Update ()
	{
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		timeString = DateTime.Now.ToString ("h:mm tt");
		dateString = DateTime.Now.ToString ("D");
		shortDateString = DateTime.Now.ToString ("d");

		timeText.text = timeString;
		dateText.text = dateString;

		checkLocationServices ();
	}

	void checkLocationServices()
	{
		coordsText.text = "___________";
		if (!(Input.location.status == LocationServiceStatus.Running) 
			&& !(Input.location.status == LocationServiceStatus.Initializing))
			pullText.text = "pull to connect";

		else if (Input.location.status == LocationServiceStatus.Initializing) 
			pullText.text = "initializing";
		
		else 
		{
			coordsText.text = latitude+", "+longitude;
			pullText.text = "pull to tag";
		}
	}
}
