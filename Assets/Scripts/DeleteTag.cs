using UnityEngine;
using System.Collections;

public class DeleteTag : MonoBehaviour 
{
	public MenuTag mt;
	public MenuManager mm;

	public void deleteTag()
	{
		mm.menuTags.Remove (mt);
		mm.destroyMenu ();
		mm.createMenu ();
	}
}
