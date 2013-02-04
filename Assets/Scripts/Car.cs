using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{
	
	private CarManager _carManager;
	private ICarState _state;
	
	enum carState
	{
		Searching,		//searching for an available fueling station
		Fueling,		//stationary at a fueling station
		Fueled,			//fully fueled, leaving the game screen
		Returning,		//looping back around to find a fueling station
	};	
	
	//public string nameTag = "car1";
	
	private float carSpeed = 1.0f;
	private float timeCharging;
	private Vector3 currentPos;
	private Vector3 targetPos;
	GameObject targetStation;
	carState currentState;
	
	// Use this for initialization
	void Start ()
	{
		//gameObject.tag = "car1";
		//find the charge station game object
		targetStation = GameObject.FindWithTag ("station1");
		//targetPos = new Vector3 (3.946276f, 1.99f, -7.31f);
		targetPos = targetStation.transform.localPosition;		
		
		//to call functions
		//targetStation.GetComponent<ChargingStation>().dosomething();
		
		
		currentState = carState.Searching;
		timeCharging = 0.0f;		
		//targetPos = new Vector3 (-0.27f, 1.99f, -7.31f);
	}	
	
	// Update is called once per frame
	void Update ()
	{
		
		//targetStation = GameObject.FindWithTag("station1");
		//targetPos = targetStation.transform.localPosition;
			
		if (currentState == carState.Searching) {
			//targetPos = targetStation.transform.localPosition;
			transform.Translate (carSpeed * Time.deltaTime, 0f, 0f);
			if (transform.position.x >= targetPos.x) {
				currentState = carState.Fueling;
				Debug.Log ("Sending tag");
				targetStation.GetComponent<ChargingStation> ().sendTag (gameObject.tag);
			}
		} else if (currentState == carState.Fueling) {
			//do nothing
		} else if (currentState == carState.Fueled) {
			transform.Translate (carSpeed * Time.deltaTime, 0f, 0f);
		} else if (currentState == carState.Returning) {
		}
		currentPos = transform.localPosition;
		
	}
	
	public void ChangeState (ICarState newState)
	{
		
	}
	
	//this function is used to find where the car should move to
	public void findTargetPos ()
	{
		
	}
	
	public void setCharged ()
	{
		currentState = carState.Fueled;
	}
}
