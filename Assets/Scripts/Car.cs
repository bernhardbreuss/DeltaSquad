using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	
	private CarManager _carManager;
	private ICarState _state;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void ChangeState(ICarState newState) {
	}
}
