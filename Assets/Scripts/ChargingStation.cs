using UnityEngine;
using System.Collections;

public class ChargingStation: MonoBehaviour {
	
	private float chargeTime = 5f;
	private PlayerPowergrid powergrid = null;
	private Car _car = null;
	public float rechargingRate = 1.0f;	
	public int incomeCar = 5;
	
	public bool IsFree { get; set; }
	
	// Use this for initialization
	void Start () {
		IsFree = true;
		//gameObject.tag = "station1";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void sendTag(string carName){
		Debug.Log("Received tag");
		GameObject car = GameObject.FindWithTag(carName);	
		Car newCar = car.GetComponent<Car>();
		_car = newCar;	
		_car.ChangeState(new StateFueling(_car));
		StartCoroutine(StartCharging());
	}
	
	public IEnumerator StartCharging() {
		
		powergrid.ConsumedEnergy += rechargingRate;
		powergrid.changeAmountEuro(incomeCar);
		IsFree = false;						
		yield return new WaitForSeconds(chargeTime);		
		ChargingFinished();		
	}
	
	public void ChargingFinished() {
		powergrid.ConsumedEnergy -= rechargingRate;
		
		_car.ChangeState(new StateLeaving(_car));
		_car = null;
		IsFree = true; 
	}
}
