using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(DragRigidbody2D))]
[RequireComponent(typeof(TagUI))]

public class TagManager : MonoBehaviour 
{
	public MenuManager mm;
	public MenuObject menuObject;
	public CanvasGroup spinner;
	public CanvasGroup warningText;
	public Text menuButton;
	public AudioSource audioSource;
	public Transform anchor;

	private float anchorOriginY;
	public float anchorNewY;
	public float speed;

	private TagUI tagUI;

	private DragRigidbody2D dr;

	private bool inMarker = false;
	private bool menuIsOpen = false;

	void Start () 
	{
		dr = GetComponent<DragRigidbody2D> ();
		tagUI = GetComponent<TagUI> ();
		anchorOriginY = anchor.transform.position.y;
	}
	
	void Update () 
	{
		if (Input.GetMouseButtonUp (0) && dr.beingDragged && inMarker) 
		{
			playSound ();
//			if (!(Input.location.status == LocationServiceStatus.Running)
//			    && !(Input.location.status == LocationServiceStatus.Initializing))
//				StartCoroutine ("StartLocationServices");
//			else
				menuObject.createMenuItem (tagUI.timeString, tagUI.shortDateString, tagUI.longitude, tagUI.latitude);

		}

		Vector3 anchorTemp = new Vector3 (anchor.position.x, anchorOriginY);

		if (menuIsOpen)
		{
			anchorTemp = new Vector3 (anchor.position.x, anchorNewY);
		}

		anchor.position = Vector3.Lerp (anchor.position, anchorTemp, speed * Time.deltaTime);
		
	}

	void playSound()
	{
		audioSource.Play ();
	}

	public void toggleTag()
	{
		if (!menuIsOpen) {
			menuIsOpen = true;
			menuButton.text = "tap to return";
			dr.enabled = false;
			mm.createMenu ();
		}

		else 
		{
			menuIsOpen = false;
			menuButton.text = "tap for saved tags";
			dr.enabled = true;
			mm.destroyMenu ();
		}
	}

	IEnumerator StartLocationServices()
	{
		Input.location.Start ();

		if (!Input.location.isEnabledByUser) 
		{
			StartCoroutine(blinkWarningText(1, "Location Services Off", 3f));
			yield break;
		}

		spinner.alpha = 1;

		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		if (Input.location.status == LocationServiceStatus.Running) 
		{
			StartCoroutine(blinkWarningText(1, "Running!", 2));
		}

		if (maxWait < 1)
		{
			spinner.alpha = 0;
			StartCoroutine(blinkWarningText(2, "Timed Out", .8f));
			yield break;
		}
	}

	IEnumerator blinkWarningText(int blinks, string text, float speed)
	{
		warningText.transform.GetComponent<Text> ().text = text;

		warningText.alpha = 1;
		yield return new WaitForSeconds (speed);
		warningText.alpha = 0;

		int i = 1;
		while (i < blinks) 
		{
			yield return new WaitForSeconds (speed);
			warningText.alpha = 1;
			yield return new WaitForSeconds (speed);
			warningText.alpha = 0;
			i++;
		}
	}

	void OnTriggerEnter2D(Collider2D col) { inMarker = true; }

	void OnTriggerExit2D(Collider2D col) { inMarker = false; }
}
