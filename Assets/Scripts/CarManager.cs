using UnityEngine;
using System.Collections.Generic;

public class CarManager: MonoBehaviour {	
	
	private WaveManager _waveManager;	
	
	void Start () {
		
	}
	
	public Car SpawnCar() {
		return null;
	}
	
	public void Destroy(Car car) {
	}
	
	public bool IsWayFree(Car car) {
		return false;
	}
}
