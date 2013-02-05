using UnityEngine;
using System.Collections.Generic;

public class CarManager: MonoBehaviour {	
	
	public WaveManager waveManager;	
	public Transform car;
	public Vector3 spawnPoint = new Vector3(368.3f,72.5f,1413.6f);
	
	void Start () {
		
	}
	
	public Car SpawnCar() {
		Instantiate(car, spawnPoint, Quaternion.identity);
		Debug.Log("Car Created");
		return null;
	}
	
	public void Destroy(Car car) {
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
