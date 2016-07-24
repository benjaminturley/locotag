using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomizeText : MonoBehaviour 
{
	public string[] options;

	public void switchText()
	{
		GetComponent<Text> ().text = options [Random.Range (0, options.Length)];
	}
}
