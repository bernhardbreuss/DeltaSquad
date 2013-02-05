using UnityEngine;


public class StateLeaving:AbstractCar
{
	public StateLeaving(Car car):base(car)
	{
		Debug.Log("State Leaving");
	}
	
	public override void Update()
	{
		_car.transform.Translate(0f, 0f, -carSpeed * Time.deltaTime);
		//if( _car.transform.localPosition.z <= 150 )
		//{
		//	_car.transform.Translate(0f,0f, 1250f);
		//	_car.ChangeState(new StateSearching(_car));
		//}
	}
}


