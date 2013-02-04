using UnityEngine;
using System.Collections;

public class HydroPlant : MonoBehaviour {
	
	private enum State {
		Idle,
		Generating,
		Pumping
	}
	
	private State _state;
	public Reservoir mountainReservoir;
	public Reservoir valleyReservoir;
	public PlayerPowergrid powergrid;
	
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
