using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	public Transform menuUIParent;
	public GameObject itemPrefab;
	public MenuObject mo;
	public float stagger;

	void Start()
	{
		//createMenu ();
	}

	public void createMenu()
	{
		for(int i = 0; i < mo.menuItems.Count; i++)
		{
			GameObject item = Instantiate(itemPrefab);
			foreach(Transform child in item.transform)
			{
				MenuTag mt = mo.menuItems [i];

				if (child.name == "Date")
					child.GetComponent<Text> ().text = mt.getDate();
				if (child.name == "Time")
					child.GetComponent<Text> ().text = mt.getTime();
				if (child.name == "Longitude")
					child.GetComponent<Text> ().text = ""+mt.getLongitude()+",";
				if (child.name == "Latitude")
					child.GetComponent<Text> ().text = ""+mt.getLatitude();
			}

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
