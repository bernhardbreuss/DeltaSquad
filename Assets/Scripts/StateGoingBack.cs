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
		_car.transform.Translate(0f, 0f, -carSpeed * Time.deltaTime);
		//if( _car.transform.localPosition.z <= 150 )
		//{
		//	_car.transform.Translate(0f,0f, 1250f);
		//	_car.ChangeState(new StateSearching(_car));
		//}
		if(_car.transform.position.z >= turningPos){
			_car.ChangeState(new StateTurning(_car, true));
		}
	}
}