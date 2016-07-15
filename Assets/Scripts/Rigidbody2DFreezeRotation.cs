using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Rigidbody2DFreezeRotation : MonoBehaviour 
{
	void Start () 
	{
		GetComponent<Rigidbody2D> ().freezeRotation = true;
	}
}
