using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoTextManager : MonoBehaviour 
{
	[SerializeField] private Text textField;
	private string inputText;
	private string tempStr;
	static int charactersPerFrame = 30;
	static float typingSpeed = .0001f;

	public void Start()
	{
		inputText = textField.text;
	}

	public void toggleTextField()
	{
		if (textField.enabled == true)
			textField.enabled = false;
		else 
		{
			textField.enabled = true;
			tempStr = "";
			StartCoroutine ("animateText");
		}
	}

	IEnumerator animateText()
	{
		int i = 0;
		while(i < inputText.Length)
		{
			for(int n = 0; n < charactersPerFrame; n++)
				if(i < inputText.Length-1)
					tempStr += inputText[i++];
			
			textField.text = tempStr;
			yield return new WaitForSeconds(typingSpeed);
		}
	}
}
