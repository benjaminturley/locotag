using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuObject : ScriptableObject 
{
	public List<MenuTag> menuItems = new List<MenuTag>();

	public void createMenuItem(string timeString, string dateString, float longitude, float latitude)
	{
		menuItems.Add(new MenuTag(timeString, dateString, longitude, latitude));
	}
}