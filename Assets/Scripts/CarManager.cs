using UnityEngine;
using System.Collections.Generic;

public class CarManager: MonoBehaviour {	
	
	public WaveManager waveManager;	
	
	void Start () {
		
	}
	
	public Car SpawnCar() {
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
