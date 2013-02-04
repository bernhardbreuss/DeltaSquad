using UnityEngine;


public class StateLeaving:AbstractCar
{
	public StateLeaving(Car car):base(car)
	{
		Debug.Log("State Leaving");
	}
	
	public override void Update()
	{
		_car.transform.Translate(carSpeed * Time.deltaTime, 0f, 0f);
	}
}


