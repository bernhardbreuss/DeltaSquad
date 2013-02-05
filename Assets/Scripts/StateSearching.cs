using UnityEngine;

public class StateSearching:AbstractCar
{
	
	private Vector3 targetPos;
	GameObject targetStation;
	
	
	public StateSearching(Car car):base(car)
	{
		Debug.Log("State Searching");
		//find the charge station game object
		targetStation = GameObject.FindWithTag("station1");
		//get the position of the charging station
		targetPos = targetStation.transform.localPosition;
	}		
	
	public override void Update()
	{
		//_car.transform
		_car.transform.Translate(0f, 0f, -carSpeed * Time.deltaTime);
		if (_car.transform.position.x >= targetPos.x)
		{							
			targetStation.GetComponent<ChargingStation>().sendTag(_car.gameObject.tag);
			
		}
	}
}


