using UnityEngine;
using System.Collections.Generic;

public class CarManager {
	
	private WaveManager _waveManager;
	private List<Car> _cars = new List<Car>();
	
	
	public Car SpawnCar() {
		return null;
	}
	
	public void Destroy(Car car) {
	}
	
	public bool IsWayFree(Car car) {
		return false;
	}
}
