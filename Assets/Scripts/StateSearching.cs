using UnityEngine;

public class StateSearching:AbstractCar
{
	
	private Vector3 targetPos;
	private float turningPos = 350.0f;
	GameObject targetStation;	
	
	public StateSearching(Car car, bool Looped):base(car)
	{	
		Debug.Log("State Searching");
		this.carLooped = Looped;
	}		
	
	public override void Update()
	{		
		_car.transform.Translate(0f, 0f, -carSpeed * Time.deltaTime);
		//If we do not already have a station to fuel at, find one
		if (_car.transform.position.z <= turningPos)
		{
			if ( !carLooped )
			{
				_car.ChangeState(new StateTurning(_car, false));
			}
			else
			{
				_car.ChangeState(new StateLeaving(_car));
			}
		}
		else if(targetStation == null)
		{
			searchForStation();
		}
		else if (_car.transform.position.z <= targetPos.z)
		{							
			_car.ChangeState(new StateFueling(_car));	
			targetStation.GetComponent<ChargingStation>().StartCharging();
		}
	}
	
	public override void stateStarted()
	{
		searchForStation();
	} 
	
	public void searchForStation()
	{		
		//find all charging station objects.
		GameObject[] tempStations = GameObject.FindGameObjectsWithTag("station1");
		
		float carPos = _car.transform.position.z;
		float stationPos;
		//find the first available station.
		foreach ( GameObject station in tempStations)
		{
			stationPos = station.GetComponent<ChargingStation>().transform.localPosition.z;
			
			if(station.GetComponent<ChargingStation>().IsFree && carPos > stationPos)
			{
				//check the station is not too far away
				if ( (carPos - stationPos) < 100.0f )
				{					
					targetStation = station;
					//get the position of the charging station.
					targetPos = targetStation.transform.localPosition;
					targetStation.GetComponent<ChargingStation>().receiveCar(this._car);
					break;
				}
				
			}
		}			
	}
}


