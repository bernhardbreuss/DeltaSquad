using UnityEngine;
using System.Collections;

public class HydroPlant : MonoBehaviour {
		
	public float MaxHealth = 100.0f;
	public float MinHealth = 0.0f;
	public float InitialHealth = 100.0f;
	
	private float _health;
	public float Health {
		get {
			return _health;
		}
		set {
			if (value < MinHealth) {
				GameOver = true;
				Time.timeScale = 0.0f;
			} else {
				value = Mathf.Min(value, MaxHealth);
			}
			
			_health = value;
		}
	}
	
	private float RepairRate = 10.0f;
	private float RepairCost = 10.0f;
	
	public bool GameOver { get; private set; }
	
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
	
	public void Repair() {
		float costs = (RepairCost * Time.deltaTime);
		
		if (costs < powergrid.Euro && (Health < MaxHealth)) {
			powergrid.changeAmountEuro(-costs);
			float repair = (RepairRate * Time.deltaTime);
			Health += repair;
		}
	}
	
}
	
