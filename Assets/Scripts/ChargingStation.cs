using UnityEngine;
using System.Collections;

public class ChargingStation : MonoBehaviour
{
	
	private float chargeTime = 5f;
	public PlayerPowergrid powerGrid;
	private Car _car;
	public float rechargingRate = 1.0f;
	
	public bool IsFree { get; set; }
	
	// Use this for initialization
	void Start ()
	{
		IsFree = true;
		//gameObject.tag = "station1";
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		
	}

	public void sendTag (string carName)
	{
		Debug.Log ("Received tag");
		GameObject car = GameObject.FindWithTag (carName);	
		Car newCar = car.GetComponent<Car> ();
		StartCoroutine (StartCharging (newCar));
	}
	
	public IEnumerator StartCharging (Car theCar)
	{
		powerGrid.ConsumedEnergy += rechargingRate;
		
		IsFree = false;
		_car = theCar;				
		yield return new WaitForSeconds(chargeTime);		
		ChargingFinished ();		
	}
	
	public void ChargingFinished ()
	{
		powerGrid.ConsumedEnergy -= rechargingRate;

		_car.setCharged ();
		_car = null;
		IsFree = true; 
	}
}
