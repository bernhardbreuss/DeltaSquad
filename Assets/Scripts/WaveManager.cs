using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
	
	public CarManager carManager;
	//public GameObject carManagerObject;
	
	private bool isFinished;
	public bool IsDay { get; set; }
	//default time between two spawned cars at the beginning
	public float baseTimeBetweenCars = 5f;
	public float TimeBetweenCars { get; set; }
	public Weather sun;
	public Weather wind;
	
	private bool _allCarsSpawned;
	
	// Use this for initialization
	IEnumerator Start () {
		isFinished = false;
		TimeBetweenCars = baseTimeBetweenCars;
		Debug.Log("Wave Manager instatiated");
		//carManager = (CarManager) carManagerObject.GetComponent("CarManager");
		yield return StartCoroutine(StartNextWave ());
	}
	
	// Update is called once per frame
	void Update () {
		 
	}
	
	public IEnumerator StartNextWave() {
		isFinished = false;
		_allCarsSpawned = false;
		IsDay = true;
		while(!isFinished){
			carManager.SpawnCar();
			sun.EnergyProductionRate += 0.1f;
			wind.EnergyProductionRate -= 0.1f;
			Debug.Log("TimeBetweenCars: " + TimeBetweenCars);
			yield return new WaitForSeconds(TimeBetweenCars);
			//weather change after served car

		}
		yield return null;
	}
	
	public void WaveFinished() {
		if (!_allCarsSpawned) {
			return;
		}
		
		isFinished = true;
		IsDay = false;
	}
}
