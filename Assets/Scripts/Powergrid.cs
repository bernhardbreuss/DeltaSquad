using UnityEngine;
using System.Collections;

public abstract class Powergrid : MonoBehaviour {
	
	public float EnergyChange = 5.0f;
	
	/*
	 *  initial value for ConsumedEnergy and ProducedEnergy
	 */
	public float baseEnergy = 100f;
	private float _consumedEnergy;
	public float ConsumedEnergy { get; set; }
	private float _producedEnergy;
	public float ProducedEnergy { get; set; }
	public float ForeignEnergy { get; set; }
	public float Frequency { get { return 50 * ((ProducedEnergy + ForeignEnergy) /ConsumedEnergy); } }
	
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
	
	protected float CurrentChange() {
		return (Time.deltaTime * EnergyChange);
	}
	
}
