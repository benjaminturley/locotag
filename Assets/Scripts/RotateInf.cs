using UnityEngine;
using System.Collections;

public class RotateInf : MonoBehaviour 
{

	public float speed = 1f;

	void Update () 
	{
		transform.Rotate(0, 0, Time.deltaTime * speed);
	}
}
