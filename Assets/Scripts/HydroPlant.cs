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
	public Reservoir mountainReservoir;
	public Reservoir valleyReservoir;
	public PlayerPowergrid powergrid;
	
	// Use this for initialization
	void Start () {
		Health = InitialHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
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
	}
	
	public void GenerateEnergy() 
	{
		
	}
}
