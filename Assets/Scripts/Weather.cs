using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour {
	
	public float EnergyProductionRate { get; set; }

	// Use this for initialization
	void Start () {
		EnergyProductionRate = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Reset(){
		EnergyProductionRate = 1f;
	}
}
