using UnityEngine;



public class StateFueling:AbstractCar
{
	public StateFueling(Car car):base(car)
	{
		Debug.Log("State Fueling");
		car.transform.Translate(35f, 0f, 0f);
	}		
	
	public override void Update()
	{
		
	}
}


