using UnityEngine;
using System.Collections;

public class HydroPlant : MonoBehaviour {
		
	private float _maxHealth = 100;
	private float _minHealth = 0;	
	private float _currentHealth = 100;
	
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
	
	public void TakeDamage(float frequency) 
	{
		float upperLimit = 10;
		float lowerLimit = 0;
		float damage = 1;
		
		if(_minHealth > 0 && frequency > upperLimit && frequency < lowerLimit)
			_currentHealth -= damage;		
	}
	
	public void Heal() 
	{
		_currentHealth = _maxHealth;		
	}
	
	public void Pump() {
	}
	
	public void GenerateEnergy() 
	{
		
	}
}
