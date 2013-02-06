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
		
		if (_cars.Count == 0) {
			waveManager.WaveFinished();
		}
	}
	
	public bool IsWayFree(Car car, float distance) {
		
		Debug.DrawRay (car.transform.position, car.transform.forward, Color.green);
		
		bool result = true;
	    RaycastHit hit = new RaycastHit();
		
	    if (Physics.Raycast(car.transform.position, car.transform.forward, out hit, distance))
		{
			//Debug.Log ("hit something");
	        
			string tag = hit.transform.tag;
			
			if (tag.Contains("Car"))
			{ 		
				Debug.Log ("car ahead");
				result = false;
	        } 
			else 
			{ 	
				result = true;
	        }
			
	    }
		else
		{
			//Debug.Log ("not hiting anything");
			result = true;	
		}
			
		
		return result;
	}
}
