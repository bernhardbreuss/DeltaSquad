using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour {
	
	private float _energyProductionRate;
	private float _changeRemain;
	private float _change;
	private float _targetValue;
	
	public GameObject Clouds;
	public GameObject Rain;
	
	public float EnergyProductionRate { 
		get {
			return _energyProductionRate;
		}
		set {
			value = Mathf.Max(value, MinEnergyProductionRate);
			_energyProductionRate = Mathf.Min(value, MaxEnergyProductionRate);
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
			float change = (_change * Time.deltaTime);
			if (EnergyProductionRate >= 0.995 && (EnergyProductionRate - change) < 0.995) {
				AudioManager.Get.playSound(AudioManager.SoundEffects.Weather);
				if (Clouds != null && Rain != null) {
					Clouds.particleEmitter.emit = true;
					Rain.particleEmitter.emit = true;
				}
			} else if (EnergyProductionRate >= 0.995 && Clouds != null && Rain != null) {
				Clouds.particleEmitter.emit = false;
				Rain.particleEmitter.emit = false;
			}
			EnergyProductionRate -= change;
			_changeRemain -= Time.deltaTime;
		} else if (_changeRemain < 0.0f) {
			_changeRemain = 0.0f;
			EnergyProductionRate = _targetValue;
		}
	}
	
	public void Reset(){
		EnergyProductionRate = 1f;
		_changeRemain = 0.0f;
	}
	
	public void ChangeTo(float newValue, float time) {
		if (time == 0.0f) {
			EnergyProductionRate = newValue;
		} else {		
			_change = (EnergyProductionRate - newValue) / time;
			_changeRemain = time;
			_targetValue = newValue;
		}
	}
}
