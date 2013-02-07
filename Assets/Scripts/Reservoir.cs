using System;
using UnityEngine;

public class Reservoir : MonoBehaviour
{
	public GameObject WaterPlane;
	public float baseLvlChange;
	public float ground;
	public float top;
	//Water in percent e.g. whole system has 100
	
	private float _water;
	public float Water {
		get {
			return _water;
		}
		set {
			if (_water >= 10.0f && value < 10.0f) {
				AudioManager.Get.playSound(AudioManager.SoundEffects.Reservoir);
			}
			_water = value;
		}
	}
	
	void Start(){
		baseLvlChange = (top - ground) / 100;
	}
	
	void Update(){
		float newPosition = Water * baseLvlChange;
		Vector3 oldPosition = WaterPlane.transform.localPosition;
		oldPosition.y = newPosition;
		WaterPlane.transform.localPosition = oldPosition;
	}
}
