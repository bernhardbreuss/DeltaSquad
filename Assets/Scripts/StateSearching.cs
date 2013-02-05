using UnityEngine;

public class StateSearching:AbstractCar
{
	
	private Vector3 targetPos;
	GameObject targetStation;	
	
	public StateSearching(Car car):base(car)
	{		
	}		
	
	public override void Update()
	{
		//_car.transform
		_car.transform.Translate(0f, 0f, -carSpeed * Time.deltaTime);
		if (_car.transform.position.z <= targetPos.z)
		{							
			_car.ChangeState(new StateFueling(_car));	
			targetStation.GetComponent<ChargingStation>().StartCharging();
		}
	}
	
	public override void stateStarted()
	{
		Debug.Log("State Searching");
		//find all charging station objects.
		GameObject[] tempStations = GameObject.FindGameObjectsWithTag("station1");
		//find the first available station.
		foreach ( GameObject station in tempStations)
		{
			if(station.GetComponent<ChargingStation>().IsFree)
			{
				targetStation = station;
				//get the position of the charging station.
				targetPos = targetStation.transform.localPosition;
				targetStation.GetComponent<ChargingStation>().receiveCar(this._car);
				break;
			}
		}		
		
		if(targetStation == null)
		{
			_car.ChangeState( new StateLeaving(_car) );
		}
	}
}


