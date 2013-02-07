using UnityEngine;
using System.Collections;


public class StateGoingBack:AbstractCar
{
	private float turningPos = 1200.0f;
	
	public StateGoingBack(Car car):base(car)
	{
		Debug.Log("State Going Back");
	}
	
	public override void Update()
	{		
		if(_car.transform.position.z >= turningPos){
			
			if ( _car.freeToMove() )
			{
				_car.ChangeState(new StateTurning(_car, true));
			}			
			
		}
		else
		{
			_car.transform.Translate(0f, 0f, -carSpeed * Time.deltaTime);
		}
	}	
}