using System;
using UnityEngine;

public class Reservoir : MonoBehaviour
{
	public GameObject WaterPlane;
	public float baseLvlChange;
	public float ground;
	public float top;
	//Water in percent e.g. whole system has 100
	public float Water { get; set; }
	
	void Start(){
		baseLvlChange = (top - ground) / 100;
	}
	
	void Update(){
		float newPosition = Water * baseLvlChange;
		Vector3 oldPosition = WaterPlane.transform.localPosition;
		oldPosition.y = newPosition;
		WaterPlane.transform.localPosition = oldPosition;
	}
}
