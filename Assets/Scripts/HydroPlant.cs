using UnityEngine;
using System.Collections;

public class HydroPlant : MonoBehaviour {
	
	private enum State {
		Idle,
		Generating,
		Pumping
	}
	
	private State _state;
	private float _consumedEnergy;
	private float _producedEnergy;
	//loss of energy if same amount of water is used for generation and pumping the water
	public float efficency = 0.7f;
	public Reservoir mountainReservoir;
	public Reservoir valleyReservoir;
	public PlayerPowergrid powergrid;
	
	// Use this for initialization
	void Start () {
		
		mountainReservoir.Water = 50;
		valleyReservoir.Water = 50;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (powergrid.ProducedEnergy < powergrid.ConsumedEnergy) {
			Pump();
		} else {
			GenerateEnergy();
		}
	}
	
	public void TakeDamage(float frequency) {
	}
	
	public void Pump() {
		
		_consumedEnergy = powergrid.baseEnergy - powergrid.ProducedEnergy;
		float waterFlow = Time.deltaTime * _consumedEnergy * efficency;
		valleyReservoir.Water -= waterFlow;
		mountainReservoir.Water += waterFlow;
	}
	
	public void GenerateEnergy() {
		
		_producedEnergy = powergrid.ProducedEnergy - powergrid.baseEnergy;
		float waterFlow = Time.deltaTime * _producedEnergy;
		valleyReservoir.Water += waterFlow;
		mountainReservoir.Water -= waterFlow;
	}
	
}
