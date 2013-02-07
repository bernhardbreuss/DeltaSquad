using UnityEngine;



public class StateFueling:AbstractCar
{
	VisualizeCharging _visualize;
	
	public StateFueling(Car car):base(car)
	{
		Debug.Log("State Fueling");
		car.transform.Translate(35f, 0f, 0f);
		
		_visualize = car.GetComponentInChildren<VisualizeCharging>();
	}		
	
	public override void Update()
	{
		
	}
	
	public override void stateStarted ()
	{
		base.stateStarted ();
		_visualize.startAnimation();
	}
	
	public override void stateFinished ()
	{
		base.stateFinished();
		_visualize.stopAnimation();
	}
}


