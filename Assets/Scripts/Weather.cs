using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour {
	
	public float energyProductionRate = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Reset(){
		energyProductionRate = 0;
	}
}
