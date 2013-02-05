using System;


public abstract class AbstractCar:ICarState
{
	public Car _car;	
	public float carSpeed = 50.0f;
	
	public AbstractCar (Car mCar)
	{
		_car = mCar;
	}
	
	public abstract void Update();
}


