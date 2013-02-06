using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour {
	
	private float _energyProductionRate;
	
	public float EnergyProductionRate { 
		get {
			return _energyProductionRate;
		}
		set {
			float tmp = value;
			tmp = Mathf.Max(tmp, MinEnergyProductionRate);
			_energyProductionRate = Mathf.Min(tmp, MaxEnergyProductionRate);
		}
	}
	
	public const float MaxEnergyProductionRate = 1.2f;
	public const float MinEnergyProductionRate = 0.8f;
	public const float ProductionRateRange = (MaxEnergyProductionRate - MinEnergyProductionRate);
	
	// Use this for initialization
	void Start () {
		EnergyProductionRate = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Reset(){
		EnergyProductionRate = 1f;
	}
}
