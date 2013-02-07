using UnityEngine;
using System.Collections.Generic;

public class CarManager: MonoBehaviour {	
	
	public WaveManager waveManager;	
	public Transform carPrefab;
	public Vector3 spawnPoint = new Vector3(368.3f,72.5f,1413.6f);
	
	private List<Car> _cars = new List<Car>();
	
	void Start () {
		
	}
	
	public Car SpawnCar() {
		Transform carTransform = Instantiate(carPrefab, spawnPoint, Quaternion.identity) as Transform;
		Car car = carTransform.GetComponent<Car>();
		car.CarManager = this;
		
		_cars.Add(car);
		
		return car;
	}
	
	public void DestroyCar(Car car) {
		Destroy(car.gameObject);
		_cars.Remove(car);
		
		if (!car.Charged) {
			waveManager.playerGrid.hydroPlant.Health -= ((HydroPlant.RepairRate * Car.IncomeCar) / HydroPlant.RepairCost);
		}
		
		if (_cars.Count == 0) {
			waveManager.WaveFinished();
		}
	}
	
	public bool IsWayFree(Car car) {
		
		float carPos = car.transform.position.z;
		
		foreach ( Car newCar in _cars)
		{
			if ( newCar != car)
			{
				Debug.Log("DEBUG : comparing other car");
				float newCarPos = newCar.transform.position.z;
				float distance = carPos - newCarPos;
				if ( distance < 50.0f && distance > -50.0f )
				{
					return false;
				}
			}
			else
			{				
				Debug.Log("DEBUG : comparing self");
			}
		}
		
		return true;
	}
}
