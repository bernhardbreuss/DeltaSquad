using UnityEngine;
using System.Collections;

public class HydroPlant : MonoBehaviour {
	
	private enum State {
		Idle,
		Generating,
		Pumping
	}
	
	private State _state;
	private Reservoir _mountainReservoir;
	private Reservoir _valleyReservoir;
	private PlayerPowergrid _powergrid;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(float frequency) {
	}
	
	public void Pump() {
	}
	
	public void GenerateEnergy() {
	}
}
