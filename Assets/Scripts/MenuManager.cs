using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuManager : MonoBehaviour
{
	public Transform menuUIParent;
	public GameObject itemPrefab;
	public float stagger;

	public List<MenuTag> menuTags = new List<MenuTag>();

	public void Start()
	{
		if(File.Exists(Application.persistentDataPath + "/menuTags.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/menuTags.gd", FileMode.Open);
			menuTags = (List<MenuTag>)bf.Deserialize(file);
			file.Close();
		}
	}

	void OnApplicationQuit()
	{
		saveGame ();
	}

	void OnApplicationPause(bool isPaused)
	{
		if (isPaused)
			saveGame ();
	}

	void saveGame()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/menuTags.gd");
		bf.Serialize(file, menuTags);
		file.Close();
	}

	public void createMenuItem(string timeString, string dateString, float longitude, float latitude)
	{
		menuTags.Insert(0, new MenuTag(timeString, dateString, longitude, latitude));
	}

	public void createMenu()
	{
		for(int i = 0; i < menuTags.Count; i++)
		{
			GameObject item = Instantiate(itemPrefab);
			foreach(Transform child in item.transform)
			{
				MenuTag mt = menuTags [i];

				if (child.name == "Date")
					child.GetComponent<Text> ().text = mt.getDate();
				if (child.name == "Time")
					child.GetComponent<Text> ().text = mt.getTime();
				if (child.name == "Latitude")
					child.GetComponent<Text> ().text = ""+mt.getLatitude ()+",";
				if (child.name == "Longitude")
					child.GetComponent<Text> ().text = ""+mt.getLongitude ();
			}

			item.GetComponent<SendToWindowManager> ().mt = menuTags [i];
			item.GetComponent<FadeInCanvasGroup> ().delay = (float)i / stagger;
			item.transform.SetParent (menuUIParent);
			item.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	public void destroyMenu()
	{
		foreach(Transform t in menuUIParent)
		{
			Destroy (t.gameObject);
		}
	}
}
