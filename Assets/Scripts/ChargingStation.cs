using UnityEngine;
using System.Collections;

public class ChargingStation: MonoBehaviour {
	
	private float chargeTime = 5f;
	public PlayerPowergrid powergrid ;
	private Car _car ;
	public float rechargingRate = 1.0f;	
	
	public bool IsFree { get; set; }
	
	// Use this for initialization
	void Start () {
		IsFree = true;
		gameObject.tag = "station1";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetPowergrid(PlayerPowergrid powrgrid)
	{
		powergrid = powrgrid;
	}
	
	public void receiveCar(Car newCar){
		Debug.Log("Received tag");		
		IsFree = false;	
		_car = newCar;			
	}
	
	public void StartCharging() {
		
		powergrid.ConsumedEnergy += rechargingRate;	
		StartCoroutine(ChargingFinished());	   	
	}
	
	public IEnumerator ChargingFinished() {
		yield return new WaitForSeconds(chargeTime);
		_car.Charged = true;
		powergrid.ConsumedEnergy -= rechargingRate;
		powergrid.changeAmountEuro(Car.IncomeCar);		
		if ( !_car.freeToMove() )
		{
			yield return new WaitForSeconds(1);
		}
		_car.transform.Translate(-35f,0f,0f);
		_car.ChangeState(new StateLeaving(_car));
		_car = null;
		IsFree = true; 
	}
}
