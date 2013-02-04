using UnityEngine;
using System.Collections;

public class ChargingStation : MonoBehaviour {
	
	private PlayerPowergrid _powergrid;
	private Car _car;
	
	public bool IsFree { get; set; }
	
	// Use this for initialization
	void Start () {
		IsFree = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartCharging() {
		_powergrid.ConsumedEnergy++;
	}
	
	public void ChargingFinished() {
		_powergrid.ConsumedEnergy--;
	}
}
