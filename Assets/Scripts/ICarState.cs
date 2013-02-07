using System;
using System.Collections;

public interface ICarState
{  	
	void Update();	
	void stateStarted();
	void stateFinished();
}
