using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
	
	public CarManager carManager;
	
	private bool isFinished;
	//default time between two spawned cars at the beginning
	public float baseTimeBetweenCars = 5f;
	public float TimeBetweenCars { get; set; }
	
	// Use this for initialization
	void Start () {
		isFinished = false;
		TimeBetweenCars = baseTimeBetweenCars;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public IEnumerator StartNextWave() {
		isFinished = true;
		while(!isFinished){
			carManager.SpawnCar();
			yield return new WaitForSeconds(TimeBetweenCars);
		}
	}
	
	public void WaveFinished() {
		isFinished = true;
	}
}
