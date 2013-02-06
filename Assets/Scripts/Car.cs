using UnityEngine;
using System.Collections;

public class Car: MonoBehaviour {
	
	//private CarManager _carManager;
	private ICarState _state;	
	
	public CarManager CarManager { get; set; }
	
	//public Car(string carTag)
	//{
	//	transform.gameObject.tag = carTag; 
	//}
	
	// Use this for initialization
	void Start () {			
		//_state = new StateSearching(this);	
		ChangeState(new StateSearching(this));
	}	
	
	// Update is called once per frame
	void Update () {			
		_state.Update();
	}
	
	public void ChangeState(ICarState newState) {
		_state = newState;
		_state.stateStarted();
	}
	
	//this function is used to find where the car should move to
	public void findTargetPos()
	{
		
	}	
	
}
