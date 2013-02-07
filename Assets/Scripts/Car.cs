using UnityEngine;
using System.Collections;

public class Car: MonoBehaviour {
	
	public const float IncomeCar = 5.0f;
	
	//private CarManager _carManager;
	private ICarState _state;
	
	public CarManager CarManager { get; set; }
	public bool Charged { get; set; }
	
	// Use this for initialization
	void Start () {			
			
		ChangeState(new StateSearching(this, false));
	}	
	
	// Update is called once per frame
	void Update () {			
		_state.Update();
	}
	
	public void ChangeState(ICarState newState) {
		if (_state != null) {
			_state.stateFinished();
		}
		
		_state = newState;
		_state.stateStarted();
	}		
	
	//call carmanager and ask if the car is free to move
	public bool freeToMove()
	{		
		return ( CarManager.IsWayFree(this) );		
	}	
}
