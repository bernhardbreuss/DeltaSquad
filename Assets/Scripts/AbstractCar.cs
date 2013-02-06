using System;


public abstract class AbstractCar:ICarState
{
	public Car _car;	
	public float carSpeed = 100.0f;
	public Boolean carLooped = false;
	public Boolean isFueled = false;
	
	public AbstractCar (Car mCar)
	{
		_car = mCar;
	}
	
	public abstract void Update();
	public virtual void stateStarted(){}
}


