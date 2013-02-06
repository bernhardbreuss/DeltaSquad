using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour {
	
	private float _energyProductionRate;
	private float _changeRemain;
	private float _change;
	private float _targetValue;
	
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
		if (_changeRemain > 0.0f) {
			EnergyProductionRate -= (_change * Time.deltaTime);
			_changeRemain -= Time.deltaTime;
		} else if (_changeRemain < 0.0f) {
			_changeRemain = 0.0f;
			EnergyProductionRate = _targetValue;
		}
	}
	
	public void Reset(){
		EnergyProductionRate = 1f;
	}
	
	public void ChangeTo(float newValue, float time) {
		_change = (EnergyProductionRate - newValue) / time;
		_changeRemain = time;
		_targetValue = newValue;
	}
}
