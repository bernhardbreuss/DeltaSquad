using UnityEngine;



public class StateFueling:AbstractCar
{
	public StateFueling(Car car):base(car)
	{
		Debug.Log("State Fueling");
	}		
	
	public override void Update()
	{
		
	}
}


