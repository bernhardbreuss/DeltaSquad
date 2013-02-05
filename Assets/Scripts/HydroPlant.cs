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
	private float _consumedEnergy;
	private float _producedEnergy;
	//loss of energy if same amount of water is used for generation and pumping the water
	public float efficency = 0.7f;
	public Reservoir mountainReservoir;
	public Reservoir valleyReservoir;
	public PlayerPowergrid powergrid;
	
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		
		mountainReservoir.Water = 50;
		valleyReservoir.Water = 50;
		
=======
		Health = InitialHealth;
>>>>>>> 1ccf952a33b2cd3fcb556b70b463003d0b454f11
	}
	
	// Update is called once per frame
	void Update () {
		if (powergrid.ProducedEnergy < powergrid.ConsumedEnergy) {
			Pump();
		} else {
			GenerateEnergy();
		}
	}
	
	public void TakeDamage(float frequency) 
	{
		float upperLimit = 10;
		float lowerLimit = 0;
		float damage = 1;
		
		if(MinHealth > 0 && frequency > upperLimit && frequency < lowerLimit)
			Health -= damage;		
	}
	
	public void Heal() 
	{
		Health = MaxHealth;		
	}
	
	public void Pump() {
		
		_consumedEnergy = powergrid.baseEnergy - powergrid.ProducedEnergy;
		float waterFlow = Time.deltaTime * _consumedEnergy * efficency;
		valleyReservoir.Water -= waterFlow;
		mountainReservoir.Water += waterFlow;
	}
	
<<<<<<< HEAD
	public void GenerateEnergy() {
		
		_producedEnergy = powergrid.ProducedEnergy - powergrid.baseEnergy;
		float waterFlow = Time.deltaTime * _producedEnergy;
		valleyReservoir.Water += waterFlow;
		mountainReservoir.Water -= waterFlow;
=======
	public void GenerateEnergy() 
	{
		
>>>>>>> 1ccf952a33b2cd3fcb556b70b463003d0b454f11
	}
	
}
