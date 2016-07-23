using UnityEngine;
using System.Collections;

[System.Serializable]
public class MenuTag
{
	[SerializeField]
	private string timeString;
	[SerializeField]
	private string dateString;
	[SerializeField]
	private float longitude;
	[SerializeField]
	private float latitude;

	public MenuTag() {}

	public MenuTag(string timeString, string dateString, float longitude, float latitude)
	{
		this.timeString = timeString;
		this.dateString = dateString;
		this.longitude = longitude;
		this.latitude = latitude;
	}

	public string getDate()
	{
		return dateString;
	}

	public string getTime()
	{
		return timeString;
	}

	public float getLatitude()
	{
		return latitude;
	}

	public float getLongitude()
	{
		return longitude;
	}
}
