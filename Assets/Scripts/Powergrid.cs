using UnityEngine;
using System.Collections;

public abstract class Powergrid : MonoBehaviour {
	
	/*
	 *  initial value for ConsumedEnergy and ProducedEnergy
	 */
	public float baseEnergy = 100f;
	private float _consumedEnergy;
	public float ConsumedEnergy {
		get {
			return _consumedEnergy;
		}
		set {
			if (value < 0) {
				_consumedEnergy = 0.0f;
			} else {
				_consumedEnergy = value;
			}
		}
	}
	private float _producedEnergy;
	public float ProducedEnergy {
		get {
			return _producedEnergy;
		}
		set {
			if (value < 0) {
				_producedEnergy = 0.0f;
			} else {
				_producedEnergy = value;
			}
		}
	}
	public float ForeignEnergy { get; set; }
	public float Frequency { get { return 50 * (ProducedEnergy/ConsumedEnergy); } }
	
	// Use this for initialization
	void Start () {
		ConsumedEnergy = baseEnergy;
		ProducedEnergy = baseEnergy;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public abstract void ProduceMoreEnergy();
	public abstract void ProduceLessEnergy();
	
	
}
