using UnityEngine;
using System.Collections;

public class ChargingStation : MonoBehaviour {
	
	public PlayerPowergrid powerGrid;
	private Car _car;
	
	public float rechargingRate = 1;
	
	public bool IsFree { get; set; }
	
	// Use this for initialization
	void Start () {
		IsFree = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartCharging() {
		powerGrid.ConsumedEnergy += rechargingRate;
	}
	
	public void ChargingFinished() {
		powerGrid.ConsumedEnergy -= rechargingRate;
	}
}
