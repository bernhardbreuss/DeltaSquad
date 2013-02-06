using UnityEngine;
using System.Collections;

public class HydroPlant : MonoBehaviour {
		
	public float MaxHealth = 100.0f;
	public float MinHealth = 0.0f;
	public float InitialHealth = 100.0f;
	
	
	public float Health { get; set; }
	
	private enum State {
		Idle,
		Generating,
		Pumping
	}
	
	private State _state;
	//loss of energy if same amount of water is used for generation and pumping the water
	public float efficency = 0.7f;
	public Reservoir mountainReservoir;
	public Reservoir valleyReservoir;
	public PlayerPowergrid powergrid;
	
	// Use this for initialization
	void Start () {
		
		mountainReservoir.Water = 50;
		valleyReservoir.Water = 50;
		Health = InitialHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (powergrid.ProducedEnergy < powergrid.ConsumedEnergy) {
			if (valleyReservoir.Water>0.0f) {
				Pump();
			} else {
				Stop();
			}
		} else {
			if(mountainReservoir.Water>0){
				GenerateEnergy();
			}else{
				Stop();
			}
		}
	}
	
	public void Heal() 
	{
		Health = MaxHealth;		
	}
	
	public void Pump() {
		float consumedEnergy = powergrid.baseEnergy - powergrid.ProducedEnergy;
		float waterFlow = Time.deltaTime * consumedEnergy * efficency;
		valleyReservoir.Water -= waterFlow;
		mountainReservoir.Water += waterFlow;
	}
	

	public void GenerateEnergy() {
		float producedEnergy = powergrid.ProducedEnergy - powergrid.baseEnergy;
		float waterFlow = Time.deltaTime * producedEnergy;
		valleyReservoir.Water += waterFlow;
		mountainReservoir.Water -= waterFlow;
	}
	
	public void Stop() {
		powergrid.ProducedEnergy = powergrid.baseEnergy;
	}
	
}
	
